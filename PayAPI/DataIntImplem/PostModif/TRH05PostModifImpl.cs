using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.PostModif;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.PostModif
{
    public class TRH05PostModifImpl : ITRH05PostModif
    {
        List<TRH05PostModif> oItemList = new List<TRH05PostModif>();
        Resultat oResultat = new Resultat();

        public async Task<List<TRH05PostModif>> GetPostModifByMatricule(string id)
        {
            oItemList = new List<TRH05PostModif>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<TRH05PostModif>("SELECT * FROM TRH05PostModif where Matricule='" + id + "'");
                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }
            return oItemList;
        }

        public async Task<Resultat> GetResutUpdate(TRH05PostModif item)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH05PostModif", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }

        public async Task<Resultat> ValiderPostModif(ParamValidPostModif param)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH05PostModifValidation", this.RenseignerPrmValid(param), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(TRH05PostModif item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Matricule", item.Matricule);
            oParameters.Add("@OldPostID", item.OldPostID);
            oParameters.Add("@NewPostID", item.NewPostID);
            oParameters.Add("@Raison", item.Raison);
            oParameters.Add("@Observations", item.Observations);
            oParameters.Add("@DatePostModif", item.DatePostModif);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }


        private DynamicParameters RenseignerPrmValid(ParamValidPostModif param)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", param.ID);
            oParameters.Add("@UserID", param.UserID);
            return oParameters;

        }
    }
}
