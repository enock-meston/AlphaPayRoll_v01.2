using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ReportData
{
    public class ListCaisseEpargne
    {
        public int Numero { get; set; }
        public string Matricule { get; set; }
        public string Branch { get; set; }
        public string NomPrenom { get; set; }
        public decimal NetAPayer { get; set; }
        public string Periode { get; set; }
    }
}
