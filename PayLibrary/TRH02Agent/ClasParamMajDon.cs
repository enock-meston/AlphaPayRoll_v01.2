using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TRH02Agent
{
    public class ClasParamMajDon
    {
        public int AgentID { set; get; }
        public string Matricule { set; get; } = "";
        public string SBranchID { set; get; } = "";
        public int ClientId { set; get; }
        public bool ViremRIPPS { set; get; }
        public int UserID { set; get; }
    }
}
