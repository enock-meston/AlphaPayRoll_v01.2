using Dapper;
using PayAPI.StringCon;
using PayLibrary.Faute;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.Faute
{
    public class TRH04FAUTEImpl : ITRH04FAUTE
    {
        List<TRH04FAUTE> itemList = new List<TRH04FAUTE>();
        Resultat oResultat = new Resultat();
        public async Task<List<TRH04FAUTE>> GetList(string id)
        {
            itemList = new List<TRH04FAUTE>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                // var items = await oCon.QueryAsync<TransJour>("Select * from TCt041TransJour");
                var items = await oCon.QueryAsync<TRH04FAUTE>("Ps_Affich_TRH04FAUTE", this.RenseignerPrmRech(id), commandType: CommandType.StoredProcedure);

                if (items != null && items.Count() > 0)
                {
                    itemList = items.ToList();
                }
            }
            return itemList;
        }
        private DynamicParameters RenseignerPrmRech(string matricule)
        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@Matricule", matricule);

            return oParameters;
        }

        public async Task<List<TRH04FAUTE>> GetListAll()
        {
            itemList = new List<TRH04FAUTE>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TRH04FAUTE>("Select * from TRH04FAUTE");
                //var List = await oCon.QueryAsync<TRH04FAUTE>("Ps_AffichAllTRH04FAUTE", commandType: CommandType.StoredProcedure);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<Resultat> GetUpdateResult(TRH04FAUTE item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH04Faute", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }

        private DynamicParameters RenseignerPrmUpdate(TRH04FAUTE item)
        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Matricule", item.Matricule);
            oParameters.Add("@TpFauteID", item.TpFauteID);
            oParameters.Add("@GraviteID", item.GraviteID);
            oParameters.Add("@DateFaute", item.DateFaute);
            oParameters.Add("@LieuFaute", item.LieuFaute);
            oParameters.Add("@Descript", item.Descript);
            oParameters.Add("@Observation", item.Observation);
            oParameters.Add("@CreatBy", item.CreatBy);
            oParameters.Add("@CreatOn", item.CreatOn);
            oParameters.Add("@LModifBy", item.LModifBy);
            oParameters.Add("@LModifOn", item.LModifOn);
            oParameters.Add("@TpMaj", item.TpMaj);

            return oParameters;
        }
    }
}
