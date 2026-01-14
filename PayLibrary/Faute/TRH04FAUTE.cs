using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayLibrary.Faute
{
   public  class TRH04FAUTE
    {
        public int ID { get; set; } = 0;
        public string Matricule { get; set; } = "";
        public int TpFauteID { get; set; } = 0;
        public int GraviteID { get; set; } = 0;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateFaute { get; set; } = DateTime.Now;
        public string LieuFaute { get; set; } = "";
        public string Descript { get; set; } = "";
        public string Observation { get; set; } = "";
        public int CreatBy { get; set; } = 0;
        public DateTime? CreatOn { get; set; } = DateTime.Now;
        public int LModifBy { get; set; } = 0;
        public DateTime? LModifOn { get; set; } = DateTime.Now;

        public int UserId { get; set; } = 0;
        public int TpMaj { get; set; } = 0;
    }
}
