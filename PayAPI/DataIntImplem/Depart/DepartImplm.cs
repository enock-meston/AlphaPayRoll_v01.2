using Dapper;
using PayAPI.StringCon;
using PayLibrary.Depart;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.Depart
{
    public class DepartImplm : IDepart
    {

        List<ClassDepart> oItemList = new List<ClassDepart>();

        Resultat oResultat = new Resultat();

        public async Task<List<ClassDepart>> GetDepart()
        {
            oItemList = new List<ClassDepart>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassDepart>("Select * from TRH04Depart");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }
            return oItemList;
        }
        public async Task<Resultat> GetResutUpdate(ClassDepart item)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_Depart", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        public async Task<List<ClassDepart>> GetDepartByMatricule(string id)
        {
            oItemList = new List<ClassDepart>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {


                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassDepart>("Ps_DepartByMatricule", this.RenseignerPrmRech(id), commandType: CommandType.StoredProcedure);


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }


            }

            return oItemList;
        }


        private DynamicParameters RenseignerPrmRech(string id)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@Matricule", id);

            return oParameters;

        }


        private DynamicParameters RenseignerPrmUpdate(ClassDepart item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Matricule", item.Matricule);
            oParameters.Add("@DateEmbauche", item.DateEmbauche);
            oParameters.Add("@DateDepart", item.DateDepart);
            oParameters.Add("@MotifDepartID", item.MotifDepartID);
            oParameters.Add("@Observation", item.Observation);
            //oParameters.Add("@ValidBy", item.ValidBy);
            //oParameters.Add("@ValidOn", item.ValidOn);
            oParameters.Add("@CreatOn", item.CreatOn);
            oParameters.Add("@CreatBy", item.CreatBy);
            oParameters.Add("@LModifBy", item.LModifBy);
            oParameters.Add("@LModifOn", item.LModifOn);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }

        public async Task<Resultat> ValiderDepart(ParamValidDepart param)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH04DepartValidation", this.RenseignerPrmValid(param), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }

        private DynamicParameters RenseignerPrmValid(ParamValidDepart param)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", param.ID);
            oParameters.Add("@UserID", param.UserID);
            return oParameters;

        }
    }
}
