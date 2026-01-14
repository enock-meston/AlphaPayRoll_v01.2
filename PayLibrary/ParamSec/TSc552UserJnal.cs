using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace PayLibrary.ParamSec
{
  public  class TSc552UserJnal
    {
        public int ID { set; get; }
        public int UserID { set; get; }
        public int JournalID { set; get; }
        public bool Allowed { set; get; }
        public bool TransAllowed { set; get; }
        public int CreatBy { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatOn { set; get; }
        public int LModifBy { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LModifOn { set; get; }
        public int TpMaj { set; get; }
    }
}
