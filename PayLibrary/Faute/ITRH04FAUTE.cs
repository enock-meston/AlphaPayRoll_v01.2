
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.Faute
{
   public interface ITRH04FAUTE
    {
        Task<List<TRH04FAUTE>> GetList(string id);
        Task<List<TRH04FAUTE>> GetListAll();
        Task<Resultat> GetUpdateResult(TRH04FAUTE item);
    }
}
