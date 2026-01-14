using PayLibrary.Contrat;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.Depart
{
    public interface IDepart
    {
        Task<List<ClassDepart>> GetDepart();
        Task<Resultat> GetResutUpdate(ClassDepart item);

        Task<List<ClassDepart>> GetDepartByMatricule(string id);

        Task<Resultat> ValiderDepart(ParamValidDepart param);

    }
}
