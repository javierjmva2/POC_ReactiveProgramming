using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using POC_ReactiveProgramming.Implementation.FenService;
using POC_ReactiveProgramming.Implementation.Lichess.Observables;
using POC_ReactiveProgramming.Interface.FanService;
using POC_ReactiveProgramming.Interface.Lichess.Observables;
using POC_ReactiveProgramming.Models.Lichess;
using System;
using System.Diagnostics;
using System.Reactive;

namespace POC_ReactiveProgramming.Hubs
{
    public class ChessHub : Hub
    {
        private IObservableLichessService _observableLichessService;
        private IFenService _fenService;
        private readonly IServiceProvider _serviceProvider;
        private static Dictionary<string, IObservableLichessService> observers = new Dictionary<string, IObservableLichessService>();
        private static object _lock = new object();
        public ChessHub(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            try
            {
                lock (_lock)
                {
                    var listKeys = observers.Where(s => s.Key.EndsWith($"_{this.Context.ConnectionId}")).Select(s => s.Key).ToList();
                    foreach (var key in listKeys)
                    {
                        observers.Remove(key);
                    }
                }
            }
            catch (Exception)
            {

            }

            return base.OnDisconnectedAsync(exception);
        }

        public async Task SubscribeChannel(string channel)
        {
            lock (_lock)
            {
                string connectionId = this.Context.ConnectionId;

                if (!observers.ContainsKey($"{channel}_{connectionId}"))
                {
                    var scope = _serviceProvider.CreateScope();
                    IHubContext<ChessHub> hubContext = scope.ServiceProvider.GetService<IHubContext<ChessHub>>();
                    _observableLichessService = scope.ServiceProvider.GetService<IObservableLichessService>();
                    _fenService = scope.ServiceProvider.GetService<IFenService>();


                    _observableLichessService.SuscribeToChannel(channel, Observer.Create<ResponseTV>(async (data) =>
                    {
                        try
                        {
                            string currentConnectionId = connectionId;
                            var innerChannel = channel;

                            if (string.IsNullOrEmpty(data.D.Fen))
                                return;



                            data.D.Image = await _fenService.GetImageAsync(new Models.FenService.RequestModel()
                            {
                                Fen = data.D.Fen,
                                Last_Move = data.D.Lm
                            });
                            await hubContext.Clients.Client(currentConnectionId).SendAsync("UpdateBoard", channel, data);
                        }
                        catch (Exception ex)
                        {
                        }
                    }));

                    observers.Add($"{channel}_{connectionId}", _observableLichessService);
                }
            }

        }
    }
}
