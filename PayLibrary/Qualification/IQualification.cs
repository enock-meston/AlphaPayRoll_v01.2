using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.Qualification
{
   public  interface IQualification
    {
        Task<List<ClassQualification>> GetQualification();
        Task<Resultat> GetResutUpdate(ClassQualification item);

        Task<List<ClassQualification>> GetQualificationRech(string id);
    }
}
