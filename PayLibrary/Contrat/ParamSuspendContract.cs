using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.Contrat
{
    public class ParamSuspendContract
    {
        public int ID { set; get; } = 0;
        public string Matricule { set; get; } = "";
        public string NumContrat { set; get; } = "";
        public int UserID { set; get; } = 0;
        public int TpMaj { set; get; } = 0;

    }
}
