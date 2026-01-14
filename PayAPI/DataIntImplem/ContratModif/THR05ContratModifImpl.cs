using Dapper;
using PayAPI.StringCon;
using PayLibrary.ContratModif;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.ContratModif
{
    public class THR05ContratModifImpl : ITHR05ContratModif
    {

        List<THR05ContratModif> oItemList = new List<THR05ContratModif>();
        Resultat oResultat = new Resultat();


        public async Task<List<THR05ContratModif>> GetContratModifByMatricule(string id)
        {
            oItemList = new List<THR05ContratModif>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<THR05ContratModif>("SELECT * FROM THR05ContratModif where Matricule='" + id + "'");
                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }
            return oItemList;
        }

        public async Task<Resultat> GetResutUpdate(THR05ContratModif item)
        {

            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_THR05ContratModif", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }

        public async Task<Resultat> ValiderContratModif(ParamValidContratModif param)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_THR05ContratModifValidation", this.RenseignerPrmValid(param), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }




        private DynamicParameters RenseignerPrmUpdate(THR05ContratModif item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Matricule", item.Matricule);
            oParameters.Add("@OldContNumber", item.OldContNumber);
            oParameters.Add("@NewContNumber", item.NewContNumber);
            oParameters.Add("@OldContTypeID", item.OldContTypeID);
            oParameters.Add("@NewContTypeID", item.NewContTypeID);
            oParameters.Add("@Raison", item.Raison);
            oParameters.Add("@Observations", item.Observations);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }


        private DynamicParameters RenseignerPrmValid(ParamValidContratModif param)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", param.ID);
            oParameters.Add("@UserID", param.UserID);
            return oParameters;

        }
    }


}
