using Dapper;
using Microsoft.Extensions.Configuration;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TxDAT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.TxDAT
{
    public class TCpt050TxDATImpl : ITCpt050TxDAT
    {

        private readonly string connectionString;
        public TCpt050TxDATImpl(IConfiguration configuratrion)
        {
            connectionString = configuratrion.GetConnectionString("ApiConnection")!;
        }

        List<TCpt050TxDAT> itemList = new List<TCpt050TxDAT>();
        Resultat oResultat = new Resultat();

        public async Task<List<TCpt050TxDAT>> GetAllData()
        {
            itemList = new List<TCpt050TxDAT>();

            using (IDbConnection oCon = new SqlConnection(connectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TCpt050TxDAT>("SELECT * from TCpt050TxDAT");

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<List<TCpt050TxDAT>> GetDataById(int id)
        {
            itemList = new List<TCpt050TxDAT>();

            using (IDbConnection oCon = new SqlConnection(connectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TCpt050TxDAT>("SELECT * FROM TCpt050TxDAT WHERE ID=" + id);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<Resultat> GetUpdateResult(TCpt050TxDAT item)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(connectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TCpt050TxDAT", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(TCpt050TxDAT item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@MontantLimInf", item.MontantLimInf);
            oParameters.Add("@MontantLimSup", item.MontantLimSup);
            oParameters.Add("@Tx4Mois", item.Tx4Mois);
            oParameters.Add("@Txt8Mois", item.Txt8Mois);
            oParameters.Add("@Tx12Mois", item.Tx12Mois);
            oParameters.Add("@Tx24Mois", item.Tx24Mois);
            oParameters.Add("@Tx36Mois", item.Tx36Mois);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }
    }
}
