using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TSL09ImputPay
{
    public class TMontConstSalaire
    {
        public int ID { set; get; }
        public string Item { set; get; }
        public string CpteDebit { set; get; }
        public string CpteCredit { set; get; }
        public decimal Montant { set; get; }
    }
}
