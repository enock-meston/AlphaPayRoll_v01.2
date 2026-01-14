using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayLibrary.Saction
{
  public  class TRH05Saction
    {
        public int ID { get; set; } = 0;
        public string Matricule { get; set; } = "";
        public int HisHerFautes { get; set; } = 0;
        public int FauteID { get; set; } = 0;
        public int TpSanctPrevID { get; set; } = 0;
        public int TpSanctRecID { get; set; } = 0;
        public string Raisons { get; set; } = "";
        public string DecidPar { get; set; } = "";
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateDebut { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateFin { get; set; } = DateTime.Now;
        public DateTime CreatOn { get; set; }= DateTime.Now;
        public int CreatBy { get; set; } = 0;
        public int LModifBy { get; set; } = 0;
        public DateTime LModifOn { get; set; } = DateTime.Now;
        public int TpMaj { get; set; }= 0;
    }
}
