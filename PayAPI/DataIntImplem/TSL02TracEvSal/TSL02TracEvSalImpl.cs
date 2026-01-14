using Dapper;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL02TracEvSal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.TSL02TracEvSal
{
    public class TSL02TracEvSalImpl : ITSL02TracEvSal
    {
        public Task<List<ClassTSL02TracEvSal>> GetTSL02TracEvSal()
        {
            throw new NotImplementedException();
        }

        public Task<Resultat> GetUpdateResult(ClassTSL02TracEvSal item)
        {
            throw new NotImplementedException();
        }

        //List<ClassTSL02TracEvSal> itemList = new List<ClassTSL02TracEvSal>();
        //Resultat oResultat = new Resultat();
        //public async Task<List<ClassTSL02TracEvSal>> GetTSL02TracEvSal()
        //{
        //    itemList = new List<ClassTSL02TracEvSal>();


        //    using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
        //    {
        //        if (oCon.State == ConnectionState.Closed) oCon.Open();
        //        var vCustomList = await oCon.QueryAsync<ClassTSL02TracEvSal>("Select * from TSL02TracEvSal");

        //        if (vCustomList != null && vCustomList.Count() > 0)
        //        {
        //            itemList = vCustomList.ToList();
        //        }
        //    }
        //    return itemList;
        //}
        //public async Task<Resultat> GetUpdateResult(ClassTSL02TracEvSal item)
        //{
        //    oResultat = new Resultat();


        //    using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
        //    {
        //        if (oCon.State == ConnectionState.Closed) oCon.Open();
        //        var vCustomList = await oCon.QueryAsync<Resultat>("Ps_TSL02TracEvSal", this.RenseignerPrm(item), commandType: CommandType.StoredProcedure);

        //        oResultat = vCustomList.FirstOrDefault();
        //    }
        //    return oResultat;
        //}
        private DynamicParameters RenseignerPrm(ClassTSL02TracEvSal item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@Numero", item.Numero);
            oParameters.Add("@DateJour ", item.DateJour);
            oParameters.Add("@Exercice ", item.Exercice);
            oParameters.Add("@Mois", item.Mois);
            oParameters.Add("@SalAction", item.SalAction);
            oParameters.Add("@CreatOn", item.CreatOn);
            oParameters.Add("@CreatBy", item.CreatBy);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }
    }
}
