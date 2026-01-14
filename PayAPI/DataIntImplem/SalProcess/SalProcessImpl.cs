using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.SalProcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.SalProcess
{
    public class SalProcessImpl : ITSL00Process
    {
        List<TSL00Process> itemList = new List<TSL00Process>();
        Resultat oResultat = new Resultat();
        public async Task<List<TSL00Process>> GetSalProcessAll()
        {

            string stringSQL = "SELECT dbo.TSL00Process.ID, dbo.TSL00Process.Exercice, dbo.TSL00Process.Mois, " +
            "dbo.TSL00Process.SalStepID, dbo.TSL00Process.DateInitialis, dbo.TSL00Process.Valid,ConstatationPass,SalairesPass,RemboursPass, " +
            "dbo.TSL00Process.DateValidation, dbo.TSL00Process.DateCalcul, dbo.TSL00Process.DateArchive, " +
            "dbo.TSL00Process.CreatBy, dbo.TSL00Process.CreatOn, dbo.TSL00Process.LModifBy, " +
            "dbo.TSL00Process.LModifOn, dbo.TSL550Step.Descript AS StepDenom " +
            "FROM dbo.TSL00Process INNER JOIN " +
            "dbo.TSL550Step ON dbo.TSL00Process.SalStepID = dbo.TSL550Step.ID ";

            itemList = new List<TSL00Process>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TSL00Process>(stringSQL);

                if (List != null && List.AsList().Count > 0)
                {
                    itemList = List.AsList();
                }
            }
            return itemList;
        }

        public async Task<List<TSL00Process>> GetSalProcessByPeriod(ParamPeriod item)
        {
            itemList = new List<TSL00Process>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TSL00Process>("Ps_ProcessByPeriode", this.ParamPeriode(item), commandType: CommandType.StoredProcedure);

                if (List != null && List.AsList().Count > 0)
                {
                    itemList = List.AsList();
                }
            }
            return itemList;

        }


        private DynamicParameters ParamPeriode(ParamPeriod item)

        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@Exercice", item.Exercice);
            oParameters.Add("@Mois", item.Mois);

            return oParameters;

        }



        public async Task<Resultat> GetUpdateResult(TSL00Process item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSL00Process", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(TSL00Process item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Exercice", item.Exercice);
            oParameters.Add("@Mois", item.Mois);
            oParameters.Add("@SalStepID", item.SalStepID);
            oParameters.Add("@DateInitialis", item.DateInitialis);
            oParameters.Add("@Valid", item.Valid);
            oParameters.Add("@DateValidation", item.DateValidation);
            oParameters.Add("@DateCalcul", item.DateCalcul);
            oParameters.Add("@DateArchive", item.DateArchive);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }

        public async Task<Resultat> GetIntialisSalResult(ParamPeriod item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_InitialiserSal", this.RenseignerPrmInitialis(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmInitialis(ParamPeriod item)

        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@Exercice", item.Exercice);
            oParameters.Add("@Mois", item.Mois);
            oParameters.Add("@RecupPT", item.RecupPT);
            oParameters.Add("@UserID", item.UserID);

            return oParameters;

        }

        public async Task<Resultat> GetCalculerSalResult(ParamPeriod item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_CalculerSalaires", this.RenseignerPrmCalculSal(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmCalculSal(ParamPeriod item)

        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@Exercice", item.Exercice);
            oParameters.Add("@Mois", item.Mois);
            oParameters.Add("@UserID", item.UserID);

            return oParameters;

        }

        public async Task<Resultat> GetArchiverSalResult(ParamPeriod item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_ArchiverSalaires", this.RenseignerPrmCalculSal(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }

            return oResultat;
        }
    }
}
