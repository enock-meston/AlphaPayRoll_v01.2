using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.Contrat
{
    public class TRH04Affectation
    {
        public int ID { set; get; } = 0;
        public string Matricule { set; get; } = "";
        public string NumContrat { set; get; } = "";
        public string SBranchID { set; get; } = "";
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateAffect { set; get; } = DateTime.Now;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateFin { set; get; } = DateTime.Now;
        public int FunctionID { set; get; } = 0;
        public int StatusID { set; get; } = 0;
        public string Observations { set; get; } = "";
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatOn { set; get; } = DateTime.Now;
        public int CreatBy { set; get; } = 0;
        public int LModifBy { set; get; } = 0;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LModifOn { set; get; } = DateTime.Now;
        public int UserID { set; get; } = 0;
        public int TpMaj { set; get; } = 0;
        public int ValidBy { set; get; } = 0;
        public DateTime? ValidOn { set; get; } = DateTime.Now;
        public string Guichet { set; get; } = "";
        public string Fonction { set; get; } = "";
    }
}
