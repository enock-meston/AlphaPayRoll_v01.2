using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.Qualification
{
   public class ClassQualification
    {
        public int ID { set; get; }
        public int ANNEE { set; get; }
        public string NUM_MATRICULE { set; get; }
        public string CONTACT { set; get; }
        public string NOM { set; get; }
        public string PRENOMS { set; get; }
        public string LIBELLE { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatOn { set; get; }
        public int CreatBy { set; get; }
        public int LModifBy { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LModifOn { set; get; }
        public int UserID { set; get; }
        public int TpMaj { set; get; }
    }
}
