using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TCl550User
{
    public class ClassTCl550User
    {
        public int ID { set; get; }
        public string UserName { set; get; }
        public string Matricule { set; get; }
        public string FullNames { set; get; }
        public string IDNumber { set; get; }
        public bool Deleted { set; get; }
        public bool Enab { set; get; }
        public bool Connected { set; get; }
        public int MaxWdraw { set; get; }
        public int MaxApprov { set; get; }
        public int MaxDisb { set; get; }
        public int MaxTransf { set; get; }
        public bool LResched { set; get; }
        public bool LRestruct { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int CanConFrom { set; get; }
        public int CanConTo { set; get; }
        public int ClientID { set; get; }
        public int RoleID { set; get; }
        public int LevelID { set; get; }
        public int BranchID { set; get; }
        public int DepatmentID { set; get; }
        public int CashAcctID { set; get; }
        public int ChefID { set; get; }
        public int PssWord { set; get; }
        public DateTime DatPswModif { set; get; }
        public DateTime UserExpD { set; get; }
        public DateTime DatPswExpD { set; get; }
        public DateTime ProfStartD { set; get; }
        public DateTime ProfExpD { set; get; }
        public DateTime DateLLogIn { set; get; }
        public DateTime DateLLogOut { set; get; }
        public DateTime CreatOn { set; get; }
        public int CreatBy { set; get; }
        public int LModifBy { set; get; }
        public DateTime LModifOn { set; get; }
        public int UserID { set; get; }
        public int TpMaj { set; get; }
    }
}
