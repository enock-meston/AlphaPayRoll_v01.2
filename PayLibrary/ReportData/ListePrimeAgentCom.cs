using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ReportData
{
    public class ListePrimeAgentCom
    {
        public string Guichet { get; set; }
        public int Numero { get; set; }
        public int ID { get; set; }
        public string TpGestinnaire { get; set; }
        public string Nom { get; set; }
        public decimal ResultatGuichet { get; set; }
        public decimal ResultCumGuichet { get; set; }
        public decimal IntGuichet { get; set; }
        public decimal InteretCredit { get; set; }
        public int NbrClientCredit { get; set; }
        public int NbrClientApport { get; set; }
        public string TpStructure { get; set; }
        public decimal PARStructure { get; set; }
        public decimal PAR { get; set; }
        public int Eligible { get; set; }
        public decimal PrimPerfo { get; set; }
        public string NomPeriode { get; set; }
    }
}
