using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.AgRegAugmBase
{
   public class TSL02AgRetCotis
    {
		public int ID { set; get; }
		public int AgentId { set; get; }
		public int TpRetId { set; get; }

        public int ExercDeb { set; get; }
        public int MoisDeb { set; get; }
        public Decimal PayMensuel { set; get; }
        public Decimal MontAPayMois { set; get; }
		public bool EnVig { set; get; }
		public string Denom { set; get; }
		public int CreatBy { set; get; }
		public DateTime CreatOn { set; get; }
		public int LModifBy { set; get; }
		public DateTime LModifOn { set; get; }
        public string NomAgent { set; get; }
        public int UserID { set; get; }
		public int TpMaj { set; get; }
	}
}
