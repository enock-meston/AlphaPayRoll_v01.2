using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.Depart
{
    public class ClassDepart
    {
        public int ID { set; get; } = 0;
        public string Matricule { set; get; } = "";
        public DateTime? DateEmbauche { set; get; } = DateTime.Now;
        public DateTime? DateDepart { set; get; } = DateTime.Now;
        public int MotifDepartID { set; get; } = 0;
        public string Observation { set; get; } = "";
        //public bool Valid { set; get; }
        public int ValidBy { set; get; } = 0;
        public DateTime? ValidOn { set; get; } = DateTime.Now;
        public DateTime? CreatOn { set; get; } = DateTime.Now;
        public int CreatBy { set; get; } = 0;
        public int LModifBy { set; get; } = 0;
        public DateTime? LModifOn { set; get; } = DateTime.Now;
        public int UserID { set; get; } = 0;
        public int TpMaj { set; get; } = 0;
        public string Names { set; get; } = "";
        public string MotifDepart { set; get; } = "";

    }
}
