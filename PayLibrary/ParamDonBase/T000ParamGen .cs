using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayLibrary.ParamDonBase
{
   public class T000ParamGen
    {
        public int ID { set; get; }
        public int IOVIndiv { set; get; }
        public int FraisMed { set; get; }
        public decimal TxComesa { set; get; }
        public decimal TauxFrais { set; get; }
        public decimal TauxFraisTIARD { set; get; }
        public decimal FraisMin { set; get; }
        public decimal TauxTVA { set; get; }
        public decimal Constante { set; get; }
        public int PrimMinComCT { set; get; }
        public int EncPrimCashCode { set; get; }
        public int EncPrimCheqCode { set; get; }
        public int EncPrimOVCode { set; get; }
        public int EmissionPrime { set; get; }
        public string ReportServer { set; get; }
        public int CollectifClient { set; get; }
        public int CpteTVA { set; get; }
        public int CpteFraisINC { set; get; }
        public int CpteFraisRC { set; get; }
        public int CpteFraisDIV { set; get; }
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
