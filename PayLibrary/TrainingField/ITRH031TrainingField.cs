using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TrainingField
{
   public interface ITRH031TrainingField
    {
        Task<List<TRH031TrainingField>> GetListAll();
    }
}
