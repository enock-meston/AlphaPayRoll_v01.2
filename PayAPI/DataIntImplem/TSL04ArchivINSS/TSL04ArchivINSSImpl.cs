using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL04ArchivINSS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataImplementation.TSL04ArchivINSS
{
    public class TSL04ArchivINSSImpl : ITSL04ArchivINSS
    {


        List<ClassTSL04ArchivINSS> oItemList = new List<ClassTSL04ArchivINSS>();

        Resultat oResultat = new Resultat();


        public async Task<List<ClassTSL04ArchivINSS>> GetTSL04ArchivINSS()
        {
            oItemList = new List<ClassTSL04ArchivINSS>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTSL04ArchivINSS>("Select * from TSL04ArchivINSS");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }


            }

            return oItemList;
        }


        public async Task<Resultat> GetResutUpdate(ClassTSL04ArchivINSS item)
        {

            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSL04ArchivINSS", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(ClassTSL04ArchivINSS item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Exercice", item.Exercice);
            oParameters.Add("@Mois", item.Mois);
            oParameters.Add("@Matricule", item.Matricule);
            oParameters.Add("@Trim", item.Trim);
            oParameters.Add("@INSS", item.INSS);
            oParameters.Add("@PlfPension", item.PlfPension);
            oParameters.Add("@PlfRisque", item.PlfRisque);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }

    }
}



