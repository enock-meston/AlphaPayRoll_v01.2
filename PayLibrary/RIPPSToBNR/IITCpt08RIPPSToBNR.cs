using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.RIPPSToBNR
{
    public interface ITCpt08RIPPSToBNR
    {
        Task<List<TCpt08RIPPSToBNR>> GetRIPPSToBNR();
        Task<Resultat> GetResutUpdate(TCpt08RIPPSToBNR item);
    }
}
