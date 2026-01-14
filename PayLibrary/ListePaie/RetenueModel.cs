using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.ListePaie
{
    public class RetenueModel
    {
        public int Numero { set; get; }
        public string Matricule { set; get; }
        public string Branch { set; get; }
        public string NomPrenom { set; get; }
        public decimal NetAPayer { set; get; }
        public string Periode { set; get; }
    }
}
