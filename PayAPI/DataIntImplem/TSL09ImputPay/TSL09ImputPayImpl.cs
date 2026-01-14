using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL09ImputPay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataImplementation.TSL09ImputPay
{
    public class TSL09ImputPayImpl : ITSL09ImputPay
    {

        List<ClassTSL09ImputPay> oItemList = new List<ClassTSL09ImputPay>();
        List<TMontConstSalaire> oConstSalList = new List<TMontConstSalaire>();

        Resultat oResultat = new Resultat();

        public async Task<List<ClassTSL09ImputPay>> GetTSL09ImputPay()
        {
            oItemList = new List<ClassTSL09ImputPay>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTSL09ImputPay>("Ps_GenerateJournalPaie", commandType: CommandType.StoredProcedure);


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }


            }

            return oItemList;
        }


        public async Task<Resultat> GetResutUpdate(ClassTSL09ImputPay item)
        {

            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSL09ImputPay", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(ClassTSL09ImputPay item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Cpte", item.Cpte);
            oParameters.Add("@Matricule", item.Matricule);
            oParameters.Add("@Descript", item.Descript);
            oParameters.Add("@Debit", item.Debit);
            oParameters.Add("@Credit", item.Credit);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }


        private DynamicParameters RenseignerPrmSalaire(ParamTransSalaire item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@Exercice", item.Exercice);
            oParameters.Add("@Mois", item.Mois);
            oParameters.Add("@UserID", item.UserID);
            return oParameters;

        }

        public async Task<Resultat> GetResutPasserConstSalaire(ParamTransSalaire item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_ImputationSalaireConstatation", this.RenseignerPrmSalaire(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }

        public async Task<Resultat> GetResutPasserSalaire(ParamTransSalaire item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_ImputationSalaireRIM", this.RenseignerPrmSalaire(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;

        }

        public async Task<Resultat> GetResutPasserRembCredit(ParamTransSalaire item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_ImputationSalaireRIMRembCred", this.RenseignerPrmSalaire(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;

        }

        public async Task<List<TMontConstSalaire>> GetConstatSalaire()
        {
            oConstSalList = new List<TMontConstSalaire>();
            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<TMontConstSalaire>("Ps_SalMajDonConstSalaire", commandType: CommandType.StoredProcedure);


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oConstSalList = vCustomList.ToList();
                }


            }

            return oConstSalList;
        }
    }
}

