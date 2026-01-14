using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.CONTRACT_GOMISE
{
    public class ClasContrat
    {
        public int ID { set; get; } = 0;
        public string NumContrat { set; get; } = "";
        public string MATRICULE { set; get; } = "";
        public int Categorie { set; get; } = 0;
        public string ContraPeriod { set; get; } = "";
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateDebut { set; get; } = DateTime.Now;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateFin { set; get; } = DateTime.Now;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateFinProbable { set; get; } = DateTime.Now;


        public int StatusID { set; get; } = 0;
        public string ContractStatus { set; get; } = "";

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateChangStatus { set; get; } = DateTime.Now;
        public string Notes { set; get; } = "";
        public int CreatBy { set; get; } = 0;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatOn { set; get; } = DateTime.Now;
        public int LModifBy { set; get; } = 0;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LModifOn { set; get; } = DateTime.Now;

        public int ValidBy { set; get; } = 0;
        public DateTime? ValidOn { set; get; } = DateTime.Now;
        public int UserID { set; get; } = 0;
        public int TpMaj { set; get; } = 0;
    }
}
