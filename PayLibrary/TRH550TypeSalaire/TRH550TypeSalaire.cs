using System;

namespace PayLibrary.TRH550TypeSalaire
{
    public class TRH550TypeSalaire
    {
        public int ID { get; set; }
        public string RICode { get; set; }
        public string Descript { get; set; }
        public bool Enab { set; get; }
        public int OrdNum { set; get; }
        public DateTime CreatOn { set; get; }
        public int CreatBy { set; get; }
        public int LModifBy { set; get; }
        public DateTime LModifOn { set; get; }
        public int UserID { set; get; }
        public int TpMaj { set; get; }
    }
}
