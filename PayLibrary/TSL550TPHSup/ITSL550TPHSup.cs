using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TSL550TPHSup
{
    public interface ITSL550TPHSup
    {
        Task<List<ClassTSL550TPHSup>> GetTSL550TPHSup();
        Task<Resultat> GetUpdateResult(ClassTSL550TPHSup item);
    }
}
