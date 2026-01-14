using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ParamDonBase
{
    public class TSc551MenuDonBase
    {
        public Int16 Id { set; get; }
        public string Groupe { set; get; }
        public string Descript { set; get; }
        public Int16 CodeRoute { set; get; }
        public string LinkPath { set; get; }
        public bool Enab { set; get; }
        public Int16 OrdNum { set; get; }
        public Int16 CreatBy { set; get; }
        public DateTime CreatOn { set; get; }
        public Int16? LModifBy { set; get; }
        public DateTime? LModifOn { set; get; }
        public int UserID { set; get; }
        public int CodeObj { set; get; }
        public int TpMaj { set; get; }
    }
}
