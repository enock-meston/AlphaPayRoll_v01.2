using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.CalculSalaire
{
    public interface ICalculerSalaire
    {
        Task<Resultat> PostCalculerSalaire(ParamCallSalaire item);
        Task<Resultat> PostArchiverSalaire(ParamCallSalaire item);
    }
}
