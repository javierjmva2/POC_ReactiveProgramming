using POC_ReactiveProgramming.Models.Lichess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_ReactiveProgramming.Interface.Lichess
{
    public interface ILichessQuery
    {
        Task GetInfoTvByChannel(string channel, IObserver<ResponseTV> observer);
    }
}
