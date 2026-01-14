using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ParamSec
{
    public class UserLoginDon
    {

        public int UserId { get; set; } = 0;
        public int VraiID { get; set; } = 0;
        public string Matricule { get; set; }
        public string UserName { get; set; } = "";
        public long MaxWdraw { get; set; } = 0;
        public long MaxApprov { get; set; } = 0;
        public int ClientID { get; set; } = 0;
        public int RoleID { get; set; } = 0;
        public string BranchID { get; set; } = "";
        public int CashAcctID { get; set; } = 0;
        public long PssWord { get; set; } = 0;
        public string Reponse { get; set; } = "";
        public string DateJour { get; set; } = "";
        public string JournalName { get; set; } = "";
        public string Branch { get; set; } = "";
        public string SubBranch { get; set; } = "";
        public string Profile { get; set; } = "";
        public bool IsLogged { get; set; } = false;
        public int LevelID { get; set; } = 0;
        public string NvFenet { get; set; } = "";
        public bool CountOpen { get; set; } = false;
        public string FullNames { get; set; } = "";





    }
}
