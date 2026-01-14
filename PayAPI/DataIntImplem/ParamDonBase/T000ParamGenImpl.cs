using Dapper;
using PayAPI.StringCon;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.ParamDonBase
{
    public class T000ParamGenImpl : IT000ParamGen
    {
        List<T000ParamGen> itemList = new List<T000ParamGen>();
        Resultat oResultat = new Resultat();


        public async Task<List<T000ParamGen>> GetList()
        {
            itemList = new List<T000ParamGen>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<T000ParamGen>("Select * from T000ParamGen");

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public Task<T000ParamGen> GetT000ParamGen(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<T000ParamGen>> GetT000ParamGenList()
        {
            throw new NotImplementedException();
        }

        public async Task<Resultat> GetUpdateResult(T000ParamGen item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_T000ParamGen", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(T000ParamGen item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@IOVIndiv", item.IOVIndiv);
            oParameters.Add("@FraisMed", item.FraisMed);
            oParameters.Add("@TxComesa", item.TxComesa);
            oParameters.Add("@TauxFrais", item.TauxFrais);
            oParameters.Add("@TauxFraisTIARD", item.TauxFraisTIARD);
            oParameters.Add("@FraisMin", item.FraisMin);
            oParameters.Add("@TauxTVA", item.TauxTVA);
            oParameters.Add("@Constante", item.Constante);
            oParameters.Add("@PrimMinComCT", item.PrimMinComCT);
            oParameters.Add("@EncPrimCashCode", item.EncPrimCashCode);
            oParameters.Add("@EncPrimCheqCode", item.EncPrimCheqCode);
            oParameters.Add("@EncPrimOVCode", item.EncPrimOVCode);
            oParameters.Add("@EmissionPrime", item.EmissionPrime);
            oParameters.Add("@ReportServer", item.ReportServer);
            oParameters.Add("@CollectifClient", item.CollectifClient);
            oParameters.Add("@CpteTVA", item.CpteTVA);
            oParameters.Add("@CpteFraisINC", item.CpteFraisINC);
            oParameters.Add("@CpteFraisRC", item.CpteFraisRC);
            oParameters.Add("@CpteFraisDIV", item.CpteFraisDIV);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }

    }
}
