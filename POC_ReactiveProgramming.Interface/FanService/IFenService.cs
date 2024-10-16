using POC_ReactiveProgramming.Models.FenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_ReactiveProgramming.Interface.FanService
{
    public interface IFenService
    {
        Task<string> GetImageAsync(RequestModel requestModel);
    }
}
