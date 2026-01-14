using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.DonIntialMois
{
    public  class AgDonIntialMois
    {
        public int ID { set; get; }
        public int AgentId { set; get; }
        public int TpRetId { set; get; }
        public int Exercice { set; get; }
        public int Mois { set; get; }
        public decimal MontAPayMois { set; get; }
        public int CreatBy { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatOn { set; get; }
        public int LModifBy { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LModifOn { set; get; }
        public int UserID { set; get; }
        public int TpMaj { set; get; }
        public string Descript { set; get; }

    }
}
