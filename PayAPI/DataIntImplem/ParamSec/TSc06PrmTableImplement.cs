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
    public class TSc06PrmTableImplement : ITSc06PrmTable
    {
        private IList<TSc06PrmTable> oTSc06PrmTableList = new List<TSc06PrmTable>();
        private TSc06PrmTable oTSc06PrmTableRecord = new TSc06PrmTable();

        public async Task<TSc06PrmTable> GetPrmTable(int Id)
        {
            oTSc06PrmTableRecord = new TSc06PrmTable();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vTSc06PrmTableRecord = await oCon.QueryAsync<TSc06PrmTable>("Select * from TSc06PrmTable where ID=" + Id);

                if (vTSc06PrmTableRecord != null && vTSc06PrmTableRecord.Count() > 0)
                {
                    oTSc06PrmTableRecord = vTSc06PrmTableRecord.FirstOrDefault();
                }
            }

            return oTSc06PrmTableRecord;
        }

        public async Task<List<TSc06PrmTable>> GetPrmTableList()
        {
            List<TSc06PrmTable> oTSc06PrmTableList = new List<TSc06PrmTable>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vTSc06PrmTableList = await oCon.QueryAsync<TSc06PrmTable>("Select * from TSc06PrmTable");

                if (vTSc06PrmTableList != null && vTSc06PrmTableList.Count() > 0)
                {
                    oTSc06PrmTableList = vTSc06PrmTableList.ToList();
                }
            }

            return oTSc06PrmTableList;
        }

        public async Task<Resultat> GetUpdateResult(TSc06PrmTable item)
        {
            Resultat oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSc06PrmTable", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);
                    oResultat = oRecord.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(TSc06PrmTable item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@TableName", item.TableName);
            oParameters.Add("@Descript", item.Descript);
            oParameters.Add("@OrdNum", item.OrdNum);
            oParameters.Add("@Enab", item.Enab);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }
    }
}
