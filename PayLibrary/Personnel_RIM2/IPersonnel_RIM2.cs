using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.Personnel_RIM2
{
   public interface IPersonnel_RIM2
    {
        Task<List<ClassPersonnel_RIM2>> GetPersonnelAll();
        Task<Resultat> GetResutUpdate(ClassPersonnel_RIM2 item);

        Task<List<ClassPersonnel_RIM2>> GetPersonnelRech(string id);
    }
}
