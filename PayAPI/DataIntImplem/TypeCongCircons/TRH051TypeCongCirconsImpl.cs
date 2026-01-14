using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TypeCongCircons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.TypeCongCircons
{
    public class TRH051TypeCongCirconsImpl : ITRH051TypeCongCircons
    {
        List<TRH051TypeCongCircons> itemList = new List<TRH051TypeCongCircons>();
        Resultat oResultat = new Resultat();
        public async Task<List<TRH051TypeCongCircons>> GetTRH051TypeCongCircons()
        {
            itemList = new List<TRH051TypeCongCircons>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();

                var results = await oCon.QueryAsync<TRH051TypeCongCircons>(
                    "Ps_GetAllTRH051TypeCongCircons",
                    commandType: CommandType.StoredProcedure
                );

                if (results != null && results.Any())
                {
                    itemList = results.ToList();
                }
            }

            return itemList;
        }


        public async Task<Resultat> UpdateTRH051TypeCongCircons(TRH051TypeCongCircons item)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH051TypeCongCircons", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }

            return oResultat;
        }

        private DynamicParameters RenseignerPrmUpdate(TRH051TypeCongCircons item)

        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@ID", item.ID);
            oParameters.Add("@RICode", item.RICode);
            oParameters.Add("@Descript", item.Descript);
            oParameters.Add("@Enab", item.Enab);
            oParameters.Add("@OrdNum", item.OrdNum);
            oParameters.Add("@CreatOn", item.CreatOn);
            oParameters.Add("@CreatBy", item.CreatBy);
            oParameters.Add("@LModifBy", item.LModifBy);
            oParameters.Add("@LModifOn", item.LModifOn);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }
    }
}
