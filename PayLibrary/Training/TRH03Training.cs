using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.Training
{
    
    public class TRH03Training
    {
        public int ID { set; get; } = 0;
        public string Matricule { set; get; } = "";
        public int FieldID { set; get; } = 0;
        public string Descript { set; get; } = "";
        public string Pays { set; get; } = "";
        public string Ville { set; get; } = "";
        public string OrganisePar { set; get; } = "";
        public string Observation { set; get; } = "";
        public DateTime? StartDate { set; get; } = DateTime.Now;
        public DateTime? EndDate { set; get; } = DateTime.Now;
        public int CreatBy { set; get; }= 0;
        public DateTime? CreatOn { set; get; } = DateTime.Now;
        public int LModifBy { set; get; } = 0;
        public DateTime? LModifOn   { set;get;} = DateTime.Now;
        public int TpMaj { get; set; } = 0;

    }
}
