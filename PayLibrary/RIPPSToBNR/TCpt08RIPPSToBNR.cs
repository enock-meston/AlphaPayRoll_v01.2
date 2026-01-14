using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.RIPPSToBNR
{
    public class TCpt08RIPPSToBNR
    {
        public int ID { set; get; }
        public int SBranchID { set; get; }
        public int ClientID { set; get; }
        public string NumCheq { set; get; }
        public int BankID { set; get; }
        public string BenefAcct { set; get; }
        public string BenefName { set; get; }
        public decimal Montant { set; get; }
        
        public DateTime DateOp { set; get; }
        public int CreatBy { set; get; }
     
        public DateTime CreatOn { set; get; }
        public int LModifBy { set; get; }
    
        public DateTime LModifOn { set; get; }
        public int UserID { set; get; }
        public int TpMaj { set; get; }

    }
}
