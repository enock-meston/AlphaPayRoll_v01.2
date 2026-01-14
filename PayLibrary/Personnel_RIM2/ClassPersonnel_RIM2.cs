using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.Personnel_RIM2
{
    public class ClassPersonnel_RIM2
    {
        public int ID { set; get; }
        public string NUM_MATRICULE { set; get; }
        public string NOM { set; get; }
        public string PRENOMS  { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DATE_NAISSANCE  { set; get; }
        public string LIEU_NAISSNACE { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DATE_EMBAUCHE{ set; get; }
        public string NUM_SECURITE_SOCIALE { set; get; }
        public string CIVILITE { set; get; }
        public string STATUT_MATRIMONIAL{ set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DATE_SECURITE_SOCIALE  { set; get; }
        public string NOM_CONJOINT  { set; get; }
        public string NUM_ALLOCATION  { set; get; }
        public string ID_PIECE_IDENTITE  { set; get; }
        public string NUMERO_PIECE { set; get; }
        public string LIBELLE { set; get; }
        public string ANCIENNETE  { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DATE_DEPART { set; get; }
        public string NATIONALITE { set; get; }
        public string CONTACT  { set; get; }
        public string PHOTO  { set; get; }
        public string PHOTO_LIEN  { set; get; }
        public string SIGNATURE { set; get; }
        public string SIGNATURE_LIEN  { set; get; }
        public string SEXE  { set; get; }
        public int CODE  { set; get; }
        public string POINT_SERVICE  { set; get; }

        public string FONCTION { set; get; }
        public string DEPARTMENT { set; get; }
        public int UNIVERSITY { set; get; }
        public string DOMAINE { set; get; }
        public string DIPLOME { set; get; }

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
