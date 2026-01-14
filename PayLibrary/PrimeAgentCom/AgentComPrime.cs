using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.PrimeAgentCom
{
    public class AgentComPrime
    {

        public string Guichet{ set; get; }
        public int Numero { set; get; }
        public int ID { set; get; }
        public string TpGestinnaire { set; get; }
        public string NOM { set; get; }
        public decimal ResultatGuichet { set; get; }
        public decimal ResultCumGuichet { set; get; }
        public decimal IntGuichet { set; get; }
        public decimal InteretCredit { set; get; }
        public decimal NbrClientCredit { set; get; }
        public decimal NbrClientApport { set; get; }
        public string TpStructure { set; get; }
        public decimal PARStructure { set; get; }
        public decimal PAR { set; get; }
        public bool Eligible { set; get; }
        public Int64 PrimRecut { set; get; }
        public Int64 PrimPerfo { set; get; }
        public Int64 PrimeDep { set; get; }
        public Int64 PrimRecouv { set; get; }
        public Int64 PrimTot { set; get; }
        public string NomPeriode { set; get; }
    }
}
