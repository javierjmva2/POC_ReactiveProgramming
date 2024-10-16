using Microsoft.Extensions.DependencyInjection;
using POC_ReactiveProgramming.Interface.Lichess;
using POC_ReactiveProgramming.Interface.Lichess.Observables;
using POC_ReactiveProgramming.Models.Lichess;
using System.Reactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_ReactiveProgramming.Implementation.Lichess.Observables
{
    public class ObservableLichessService : IObservableLichessService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILichessQuery _lichessQuery;
        public ObservableLichessService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _lichessQuery = _serviceProvider.GetService<ILichessQuery>();
        }

        public void SuscribeToChannel(string channel, IObserver<ResponseTV> observer)
        {
            _lichessQuery.GetInfoTvByChannel(channel, observer);
        }
    }
}
