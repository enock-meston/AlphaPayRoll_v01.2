using Dapper;
using PayAPI.StringCon;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace PayAPI.DataIntImplem.ParamSec
{
    public class TSc552UserJnalImpl : ITSc552UserJnal
    {
        List<TSc552UserJnal> itemList = new List<TSc552UserJnal>();
        Resultat oResultat = new Resultat();

        public Task<List<TSc552UserJnal>> GetJrnalUserType(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TSc552UserJnal>> GetList(int id)
        {
            itemList = new List<TSc552UserJnal>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TSc552UserJnal>("Select * from TSc552UserJnal");

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<Resultat> GetUpdateResult(TSc552UserJnal item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSc552UserJnal", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(TSc552UserJnal item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@JournalID", item.JournalID);
            oParameters.Add("@Allowed", item.Allowed);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }


    }
}
