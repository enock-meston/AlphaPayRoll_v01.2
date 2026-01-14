using Dapper;
using Microsoft.Extensions.Configuration;
using PayLibrary.General;
using PayLibrary.TCt550TpTransTout;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace PayAPI.DataImplementation.DonBase
{
    public class TCt550TpTransToutImpl : ITCt550TpTransTout
    {

        private readonly string connectionString;
        public TCt550TpTransToutImpl(IConfiguration configuratrion)
        {
            connectionString = configuratrion.GetConnectionString("ApiConnection")!;
        }

        List<TCt550TpTransTout> itemList = new List<TCt550TpTransTout>();
        Resultat oResultat = new Resultat();

        public async Task<List<TCt550TpTransTout>> GetAllTrans()
        {
            itemList = new List<TCt550TpTransTout>();

            using (IDbConnection oCon = new SqlConnection(connectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TCt550TpTransTout>("SELECT * from TCt550TpTransTout");

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<List<TCt550TpTransTout>> GetTransById(int id)
        {
            itemList = new List<TCt550TpTransTout>();

            using (IDbConnection oCon = new SqlConnection(connectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TCt550TpTransTout>("SELECT * FROM TCt550TpTransTout WHERE ID=" + id);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<Resultat> GetUpdateResult(TCt550TpTransTout item)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(connectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TCt550TpTransTout", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(TCt550TpTransTout item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@RICode", item.RICode);
            oParameters.Add("@Descript", item.Descript);
            oParameters.Add("@PasPar", item.PasPar);
            oParameters.Add("@SensJournal", item.SensJournal);
            oParameters.Add("@CpteDebit", item.CpteDebit);
            oParameters.Add("@CpteCredit", item.CpteCredit);
            oParameters.Add("@OrdNum", item.OrdNum);
            oParameters.Add("@Enab", item.Enab);
            oParameters.Add("@PassPar", item.PassPar);
            oParameters.Add("@CreatBy", item.CreatBy);
            oParameters.Add("@CreatOn", item.CreatOn);
            oParameters.Add("@LModifBy", item.LModifBy);
            oParameters.Add("@LModifOn", item.LModifOn);
            oParameters.Add("@TpJournalID", item.TpJournalID);
            oParameters.Add("@TxRetrait", item.TxRetrait);
            oParameters.Add("@RoleValidation", item.RoleValidation);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }
    }

}
