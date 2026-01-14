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
    public class TGAs55GarantieImpl : ITGAs55Garantie
    {
        List<TGAs55Garantie> itemList = new List<TGAs55Garantie>();
        Resultat oResultat = new Resultat();



        public async Task<List<TGAs55Garantie>> GetGarantieProdList(int id)
        {
            itemList = new List<TGAs55Garantie>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TGAs55Garantie>("Ps_GaranteParProduit", RenseignerPrmParent(id), commandType: CommandType.StoredProcedure);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }


        private DynamicParameters RenseignerPrmParent(int Param)
        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@ProduitID", Param);

            return oParameters;

        }


        public async Task<Resultat> GetUpdateResult(TGAs55Garantie item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TGAs55Garantie", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }



        private DynamicParameters RenseignerPrmUpdate(TGAs55Garantie item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Produit", item.Produit);
            oParameters.Add("@GarantId", item.GarantId);
            oParameters.Add("@CpteExt", item.CpteExt);
            oParameters.Add("@Descript", item.Descript);
            oParameters.Add("@Enab", item.Enab);
            oParameters.Add("@NumOrdre", item.NumOrdre);
            oParameters.Add("@TpGarant", item.TpGarant);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }
    }
}
