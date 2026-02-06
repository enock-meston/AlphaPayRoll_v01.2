
using Dapper;
using Microsoft.Extensions.Configuration;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.PlanningConge;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;



namespace PayAPI.DataIntImplem.PlanningConge
{
    public class ITHRPlanningCongeImpl : ITHRPlanningConge
    {
        private readonly string _connectionString;

        public ITHRPlanningCongeImpl(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ApiConnection");
        }


        List<THRPlanningConge> itemList = new List<THRPlanningConge>();

        Resultat oResultat = new Resultat();

        public async Task<List<THRPlanningConge>> GetAllPlanningConge()
        {
            itemList = new List<THRPlanningConge>();

            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                if (dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection.Open();
                }

                // Query the database using Dapper
                var list = await dbConnection.QueryAsync<THRPlanningConge>("SELECT * FROM THRPlanningConge", commandType: CommandType.Text);
              
                if (list != null)
                {
                    itemList = list.ToList();
                }
            }

            return itemList;
        }


        public async Task<List<THRPlanningConge>> GetPlanningCongeBySBranch(int SBranch)
        {
            itemList = new List<THRPlanningConge>();

            using (IDbConnection oCon = new SqlConnection(_connectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<THRPlanningConge>("SELECT * FROM THRPlanningConge WHERE SBranchID=" + SBranch);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }



        public async Task<Resultat> UpdatePlanningConge(THRPlanningConge item)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(_connectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();

                    var oRecord = await oCon.QueryAsync<Resultat>(
                        "Ps_THRPlanningConge",
                        this.RenseignerPrmUpdate(item),
                        commandType: CommandType.StoredProcedure
                    );

                    oResultat = oRecord.FirstOrDefault();

                    // If null, create a default result
                    if (oResultat == null)
                    {
                        oResultat = new Resultat { Result = "No result returned from stored procedure" };
                    }
                }
            }
            catch (Exception ex)
            {
                oResultat.Result = $"Error: {ex.Message}";
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(THRPlanningConge item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Exercice", item.Exercice);
            oParameters.Add("@Matricule", item.Matricule);
            oParameters.Add("@ProposMois", item.ProposMois);
            oParameters.Add("@ApprovMois", item.ApprovMois);
            oParameters.Add("@SBranchID", item.SBranchID);
            oParameters.Add("@NumTranche", item.NumTranche);
            oParameters.Add("@ProposNbreJour", item.ProposNbreJour);
            oParameters.Add("@ApprovNbreJour", item.ApprovNbreJour);
            oParameters.Add("@NbrJourPris", item.NbrJourPris);
            oParameters.Add("@Remark", item.Remark);
            oParameters.Add("@StatusChefD", item.StatusChefD);
            oParameters.Add("@StatusHR", item.StatusHR);
            oParameters.Add("@RemChefD", item.RemChefD);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);

            return oParameters;

        }



        public async Task<List<THRPlanningConge>> GetPlanningCongeByMatricule(string id)
        {
            using (IDbConnection oCon = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM THRPlanningConge WHERE Matricule = @Matricule";

                var result = await oCon.QueryAsync<THRPlanningConge>(
                    sql,
                    new { Matricule = id }
                );

                return result.ToList();
            }
        }

        public async Task<Resultat> GetNumTranche(ParamNumTranche param)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_GetNumTranchCong", this.RenseignerPrmNumTranche(param), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }

        private DynamicParameters RenseignerPrmNumTranche(ParamNumTranche param)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@Matricule", param.Matricule);
            return oParameters;

        }
    }
}
