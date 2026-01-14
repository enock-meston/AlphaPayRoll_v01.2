using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL04ArchivIPR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataImplementation.TSL04ArchivIPR
{
    public class TSL04ArchivIPRImpl : ITSL04ArchivIPR
    {


        List<ClassTSL04ArchivIPR> oItemList = new List<ClassTSL04ArchivIPR>();

        Resultat oResultat = new Resultat();


        public async Task<List<ClassTSL04ArchivIPR>> GetTSL04ArchivIPR()
        {
            oItemList = new List<ClassTSL04ArchivIPR>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTSL04ArchivIPR>("Select * from TSL04ArchivIPR");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }


            }

            return oItemList;
        }


        public async Task<Resultat> GetResutUpdate(ClassTSL04ArchivIPR item)
        {

            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSL04ArchivIPR", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(ClassTSL04ArchivIPR item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Exercice", item.Exercice);
            oParameters.Add("@Mois", item.Mois);
            oParameters.Add("@Matricule", item.Matricule);
            oParameters.Add("@BrutImpos", item.BrutImpos);
            oParameters.Add("@Tranche1", item.Tranche1);
            oParameters.Add("@Tranche2", item.Tranche2);
            oParameters.Add("@Tranche3", item.Tranche3);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }

    }
}

