using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;

namespace PayLibrary.CongConsult
{
    public class CongConsultStatus
    {
        public DateTime DateDemande {  get; set; }
        public int NombreJour { get; set; } = 0;
        public string EmployValid { get; set; } = "";
        public string ChefDirectStatus { get; set; } = "";
        public string HRStatus { get; set; } = "";
        public string DGStatus { get; set; } = "";
        public DateTime DateCongeAccourd { get; set; }

    }
}
