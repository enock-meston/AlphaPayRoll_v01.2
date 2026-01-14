using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.PostModif
{
    public class TRH05PostModif
    {
        public int ID { set; get; } = 0;
        public string Matricule { set; get; } = "";
        public string OldPostID { get; set; } = "";
        public string NewPostID { get; set; } = "";
        public string Raison { get; set; } = "";
        public string Observations { get; set; } = "";
        public DateTime? DatePostModif { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatOn { set; get; } = DateTime.Now;
        public int CreatBy { set; get; } = 0;
        public int LModifBy { set; get; } = 0;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LModifOn { set; get; } = DateTime.Now;
        public int ValidBy { set; get; } = 0;
        public DateTime? ValidOn { set; get; } = DateTime.Now;
        public int UserID { set; get; } = 0;
        public int TpMaj { set; get; } = 0;
    }
}
