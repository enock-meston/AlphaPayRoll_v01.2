using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.FauteTRH055
{
    public class TRH055FAUTE
    {
        public int ID { set; get; }
        public string RICode { set; get; }
        public string Descript { set; get; }
        public string Details { set; get; }
        public bool Enab { set; get; }
        public int OrdNum { set; get; }
        public int CreatBy { set; get; }
        public DateTime CreatOn { set; get; }
        public int LModifBy { set; get; }
        public DateTime LModifOn { set; get; }
    }
}
