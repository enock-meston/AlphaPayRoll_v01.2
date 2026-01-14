
using Dapper;
using PayAPI.StringCon;
using PayLibrary.IReport;
using PayLibrary.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.Report
{
    public class TVeh99RapportImpl : ITVeh99Rapport
    {
        List<TVeh99Rapport> itemList = new List<TVeh99Rapport>();
        public async Task<List<TVeh99Rapport>> GetList(string id)
        {
            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                itemList = new List<TVeh99Rapport>();

                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TVeh99Rapport>("Ps_TVeh99Rapport", RenseignerPrm(id), commandType: CommandType.StoredProcedure);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<List<TVeh99Rapport>> GetTout()
        {
            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                itemList = new List<TVeh99Rapport>();

                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TVeh99Rapport>("Ps_TVeh99RapportTout", commandType: CommandType.StoredProcedure);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }
        private DynamicParameters RenseignerPrm(string id)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@Concerne", id);

            return oParameters;

        }
    }
}
