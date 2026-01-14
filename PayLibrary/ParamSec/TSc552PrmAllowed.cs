using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayLibrary.ParamSec
{
    public class TSc552PrmAllowed
    {
        public int ID { set; get; }
        public string Module { set; get; }
        public int PrmTableID { set; get; }
        public int MUserID { set; get; }
        public bool SelectAllowed { set; get; }
        public bool InsertAllowed { set; get; }
        public bool UpdateAllowed { set; get; }
        public bool DeleteAllowed { set; get; }
        public int CreatBy { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatOn { set; get; }
        public int LModifBy { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LModifOn { set; get; }
        public string MUserName { set; get; }
        public string SDonBaseName { set; get; }
        public int UserID { set; get; }
        public int TpMaj { set; get; }
    }
}
