using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.PrimeAgentCom
{
    public class ClasPrimeListePay
    {

        public string Branch { set; get; }
        public int Numero { set; get; }
        public string Fonction { set; get; }
        public string NOM { set; get; }
        public decimal PrimPerfo { set; get; }
        public decimal PrimeImpos { set; get; }
        public decimal TPR { set; get; }
        public decimal CotisSociale { set; get; }
        public decimal MutSante { set; get; }
        public decimal TotalRetenue { set; get; }
        public decimal Net { set; get; }
        public decimal CSR { set; get; }
        public string NomPeriode { set; get; }
    }
}
