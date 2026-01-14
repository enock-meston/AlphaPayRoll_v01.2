using System;

namespace PayLibrary.TCt550TpTransTout
{
    public class TCt550TpTransTout
    {
        public int ID { get; set; }
        public string RICode { get; set; }
        public string Descript { get; set; }
        public string PasPar { get; set; }
        public string SensJournal { get; set; }
        public int CpteDebit { get; set; }
        public int CpteCredit { get; set; }
        public int OrdNum { get; set; }
        public bool Enab { get; set; }
        public string PassPar { get; set; }
        public int CreatBy { get; set; }
        public DateTime? CreatOn { get; set; }
        public int LModifBy { get; set; }
        public DateTime? LModifOn { get; set; }
        public int TpJournalID { get; set; }
        public decimal TxRetrait { get; set; }
        public int RoleValidation { get; set; }
        public int TpMaj { get; set; }
    }
}
