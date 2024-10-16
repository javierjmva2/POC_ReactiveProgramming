using POC_ReactiveProgramming.Models.Lichess;
using System.Reactive;

namespace POC_ReactiveProgramming.Interface.Lichess.Observables
{
    public interface IObservableLichessService
    {
        void SuscribeToChannel(string channel, IObserver<ResponseTV> observer);
    }
}
