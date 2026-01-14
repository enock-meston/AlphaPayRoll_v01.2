using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Personnel_RIM2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.Personnel_RIM2
{
    public class Personnel_RIM2Implm : IPersonnel_RIM2
    {
        List<ClassPersonnel_RIM2> oItemList = new List<ClassPersonnel_RIM2>();

        Resultat oResultat = new Resultat();

        public async Task<List<ClassPersonnel_RIM2>> GetPersonnelAll()
        {
            oItemList = new List<ClassPersonnel_RIM2>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassPersonnel_RIM2>("Select * from Personnel_RIM2");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }


            }

            return oItemList;
        }
        public async Task<List<ClassPersonnel_RIM2>> GetPersonnelRech(string id)
        {
            oItemList = new List<ClassPersonnel_RIM2>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassPersonnel_RIM2>("Ps_Personnel_RIM2RechName", this.RenseignerPrmRech(id), commandType: CommandType.StoredProcedure);


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }


            }

            return oItemList;
        }


        private DynamicParameters RenseignerPrmRech(string id)

        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@NOM", id);
            oParameters.Add("@PRENOMS", id);
            oParameters.Add("@NUM_MATRICULE", id);

            return oParameters;

        }

        public async Task<Resultat> GetResutUpdate(ClassPersonnel_RIM2 item)
        {


            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_Personnel_RIM2", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(ClassPersonnel_RIM2 item)
        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@ID", item.ID);
            oParameters.Add("@NUM_MATRICULE", item.NUM_MATRICULE);
            oParameters.Add("@NOM", item.NOM);
            oParameters.Add("@PRENOMS", item.PRENOMS);
            oParameters.Add("@DATE_NAISSANCE", item.DATE_NAISSANCE);
            oParameters.Add("@LIEU_NAISSNACE", item.LIEU_NAISSNACE);
            oParameters.Add("@DATE_EMBAUCHE", item.DATE_EMBAUCHE);
            oParameters.Add("@NUM_SECURITE_SOCIALE", item.NUM_SECURITE_SOCIALE);
            oParameters.Add("@CIVILITE ", item.CIVILITE);
            oParameters.Add("@STATUT_MATRIMONIAL", item.STATUT_MATRIMONIAL);
            oParameters.Add("@DATE_SECURITE_SOCIALE ", item.DATE_SECURITE_SOCIALE);
            oParameters.Add("@NOM_CONJOINT", item.NOM_CONJOINT);
            oParameters.Add("@NUM_ALLOCATION", item.NUM_ALLOCATION);
            oParameters.Add("@ID_PIECE_IDENTITE", item.ID_PIECE_IDENTITE);
            oParameters.Add("@NUMERO_PIECE", item.NUMERO_PIECE);
            oParameters.Add("@LIBELLE", item.LIBELLE);
            oParameters.Add("@ANCIENNETE", item.ANCIENNETE);
            oParameters.Add("@DATE_DEPART", item.DATE_DEPART);
            oParameters.Add("@NATIONALITE ", item.NATIONALITE);
            oParameters.Add("@CONTACT", item.CONTACT);
            oParameters.Add("@PHOTO", item.PHOTO);
            oParameters.Add("@PHOTO_LIEN", item.PHOTO_LIEN);
            oParameters.Add("@SIGNATURE", item.SIGNATURE);
            oParameters.Add("@SIGNATURE_LIEN", item.SIGNATURE_LIEN);
            oParameters.Add("@SEXE", item.SEXE);
            oParameters.Add("@CODE", item.CODE);
            oParameters.Add("@POINT_SERVICE ", item.POINT_SERVICE);

            oParameters.Add("@FONCTION", item.FONCTION);
            oParameters.Add("@DEPARTMENT", item.DEPARTMENT);
            oParameters.Add("@UNIVERSITY ", item.UNIVERSITY);
            oParameters.Add("@DOMAINE ", item.DOMAINE);
            oParameters.Add("@DIPLOME ", item.DIPLOME);

            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);

            return oParameters;

        }
    }
}
