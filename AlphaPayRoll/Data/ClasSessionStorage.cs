using System;

namespace AlphaPayRoll.Data
{
    public class ClasSessionStorage
    {
        public bool IsLogged { set; get; }
        public int VraiID { set; get; }
        public string UserId { set; get; } = "";
        public string UserName { set; get; } = "";
        public string Matricule { set; get; } = "";
        public string BranchID { set; get; } = "";
        public string Branch { set; get; } = "";
        public string SubBranch { set; get; } = "";
        public int CashAcctID { set; get; } 
        public string JournalName { set; get; } = "";
        public int RoleID { set; get; }
        public string UserProfile { set; get; } = "";
        public int ClientID { set; get; }
        public DateTime DateJour { set; get; }
        public string Reponse { set; get; } = "";
        public string MenuId { set; get; } = "";
        public string MenuSecId { set; get; } = "";
        public string MenuName { set; get; } = "";
        public string MenuSecName { set; get; } = "";
        public string DivMessage { set; get; } = "";
        public string CustomerNames { set; get; } = "";
        public bool DataChanged { set; get; }
        public int ContratID { set; get; }
        public int DernSouscriptID { set; get; }
        public int DernFlotID { set; get; }
        public string JournalEncaisBank { set; get; } = "";
        public int LevelID { set; get; }
        public bool CountOpen { set; get; }
        public string NvFenet { set; get; } = "";
        public string sApp { set; get; } = "";
        public string sAppMenu { set; get; } = "";
        
        public string selectedSBranchID { set; get; } = "";
        public string selectedBranch { set; get; } = "";
        public string selectedSubBranch { set; get; } = "";
        public string FullNames { set; get; } = "";
        public bool AfficherLogin { set; get; } = true;

    }
}
