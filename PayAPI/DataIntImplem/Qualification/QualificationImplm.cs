using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Qualification;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.Qualification
{
    public class QualificationImplm : IQualification
    {
        List<ClassQualification> oItemList = new List<ClassQualification>();

        Resultat oResultat = new Resultat();

        public async Task<List<ClassQualification>> GetQualification()
        {
            oItemList = new List<ClassQualification>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassQualification>("Select * from Qualification");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }
            return oItemList;
        }


        public async Task<List<ClassQualification>> GetQualificationRech(string id)
        {
            oItemList = new List<ClassQualification>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassQualification>("Ps_QualificationName", this.RenseignerPrmRech(id), commandType: CommandType.StoredProcedure);


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

            oParameters.Add("@NOM", id);
            oParameters.Add("@PRENOMS", id);
            oParameters.Add("@NUM_MATRICULE", id);

            return oParameters;

        }





        public async Task<Resultat> GetResutUpdate(ClassQualification item)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_Qualification", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }

            return oResultat;
        }
        private DynamicParameters RenseignerPrmUpdate(ClassQualification item)
        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@ID", item.ID);
            oParameters.Add("@ANNEE", item.ANNEE);
            oParameters.Add("@NUM_MATRICULE", item.NUM_MATRICULE);
            oParameters.Add("@CONTACT", item.CONTACT);
            oParameters.Add("@NOM", item.NOM);
            oParameters.Add("@PRENOMS", item.PRENOMS);
            oParameters.Add("@LIBELLE", item.LIBELLE);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }
    }
}
