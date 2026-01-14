using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TRH02Agent;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataImplementation.TRH02Agent
{

    public class TRH02AgentImpl : ITRH02Agent

    {

        List<ClassTRH02Agent> oItemList = new List<ClassTRH02Agent>();
        //ClassTRH02Agent oAgent = new ClassTRH02Agent();
        Resultat oResultat = new Resultat();

        public async Task<List<ClassTRH02Agent>> GetAgent()
        {
            oItemList = new List<ClassTRH02Agent>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTRH02Agent>("SELECT *,DATEDIFF(YEAR, DateRecrutment, GETDATE()) AS ANCIENNETE FROM TRH02Agent;");
                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }
            return oItemList;
        }
        public async Task<List<ClassTRH02Agent>> GetAgentRech(string id)
        {
            oItemList = new List<ClassTRH02Agent>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTRH02Agent>("Ps_RechPersonneName", this.RenseignerPrmRech(id), commandType: CommandType.StoredProcedure);


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
            oParameters.Add("@Nom", id);

            return oParameters;
        }
        public async Task<Resultat> GetResutUpdate(ClassTRH02Agent item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH02Agent", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }
        private DynamicParameters RenseignerPrmUpdate(ClassTRH02Agent item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.AgentId);
            oParameters.Add("@ClientId", item.ClientId);
            oParameters.Add("@Nom", item.Nom);
            oParameters.Add("@Prenom", item.Prenom);
            oParameters.Add("@DateNais", item.DateNais);
            oParameters.Add("@Sexe", item.Sexe);
            oParameters.Add("@EtatCivId", item.EtatCivId);
            oParameters.Add("@NbrepCharge", item.NbrepCharge);
            oParameters.Add("@BranchId", item.BranchLocID);
            oParameters.Add("@DepartementId", item.DepartementId);
            oParameters.Add("@FonctionId", item.FonctionId);
            oParameters.Add("@DateRecrutment", item.DateRecrutment);
            oParameters.Add("DateDepart", item.DateDepart);
            oParameters.Add("@Telephone", item.Telephone);
            oParameters.Add("@IdNum", item.IdNum);
            oParameters.Add("@Email", item.Email);
            oParameters.Add("@NumCSR", item.NumCSR);
            oParameters.Add("@NivEtudId", item.NivEtudId);
            oParameters.Add("@DomEtudId", item.DomEtudId);
            oParameters.Add("@DiplomId", item.DiplomId);
            oParameters.Add("@UniverId", item.UniverId);
            oParameters.Add("@StatusId", item.StatusId);
            oParameters.Add("@NumOrdre", item.NumOrdre);
            oParameters.Add("@CpteCredit", item.CpteCredit);
            oParameters.Add("@CpteAvance", item.CpteAvance);
            oParameters.Add("@CptApVie", item.CptApVie);
            oParameters.Add("Matricule", item.Matricule);
            oParameters.Add("SBranchLocID", item.SBranchLocID);
            oParameters.Add("@SBranchCpteId", item.SBranchCpteID);
            oParameters.Add("@BranchCpteID", item.BranchCpteID);
            oParameters.Add("Code", item.Code);
            oParameters.Add("LIEU_NAISSNACE", item.LIEU_NAISSNACE);
            oParameters.Add("NUM_SECURITE_SOCIALE", item.NUM_SECURITE_SOCIALE);
            oParameters.Add("NOM_CONJOINT", item.NOM_CONJOINT);
            oParameters.Add("NUM_ALLOCATION", item.NUM_ALLOCATION);
            oParameters.Add("NUMERO_PIECE", item.NUMERO_PIECE);
            oParameters.Add("LIBELLE", item.LIBELLE);
            oParameters.Add("ANCIENNETE", item.ANCIENNETE);
            oParameters.Add("NATIONALITE", item.NATIONALITE);
            oParameters.Add("@CongRetard", item.CongRetard);
            oParameters.Add("@CongCurrentYear", item.CongCurrentYear);
            oParameters.Add("@CongPris", item.CongPris);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);

            return oParameters;

        }

        public async Task<Resultat> GetUpdateDon(ClasParamMajDon item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_AgentDonModif", this.RenseignerMajDon(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;


        }

        private DynamicParameters RenseignerMajDon(ClasParamMajDon item)
        {

            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@AgentID", item.AgentID);
            oParameters.Add("@Matricule", item.Matricule);
            oParameters.Add("@SBranchID", item.SBranchID);
            oParameters.Add("@ClientId", item.ClientId);
            oParameters.Add("@ViremRIPPS", item.ViremRIPPS);
            oParameters.Add("@UserID", item.UserID);

            return oParameters;
        }


        public async Task<Resultat> GetResutMajSalaire(ClassTRH02Agent item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH02AgentSalaire", this.RenseignerMajSalaire(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }

        private DynamicParameters RenseignerMajSalaire(ClassTRH02Agent item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@AgentId", item.AgentId);
            oParameters.Add("@ClientId", item.ClientId);
            oParameters.Add("@Nom", item.Nom);
            oParameters.Add("@Prenom", item.Prenom);
            oParameters.Add("@SBranchLocId", item.SBranchLocID);
            oParameters.Add("@SBranchCpteId", item.SBranchCpteID);
            oParameters.Add("@BranchCpteID", item.BranchCpteID);
            oParameters.Add("@StatusId", item.StatusId);
            oParameters.Add("@IndemAutre", item.IndemAutre);
            oParameters.Add("@Matricule", item.Matricule);
            oParameters.Add("@Primes", item.Primes);
            oParameters.Add("@ViremRIPPS", item.ViremRIPPS);
            oParameters.Add("@BanqPaySalaire", item.BanqPaySalaire);
            oParameters.Add("@CpteAutreBanq", item.CpteAutreBanq);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);

            return oParameters;
        }

        public Task<Resultat> GetCalculerSalaire(ClassTRH02Agent item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ClassTRH02Agent>> GetAgentByMatricule(string id)
        {

            oItemList = new List<ClassTRH02Agent>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTRH02Agent>("Ps_TRH02AgentByMatricule", this.RenseignerPrmMatricule(id), commandType: CommandType.StoredProcedure);


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }


            }

            return oItemList;
        }


        private DynamicParameters RenseignerPrmMatricule(string id)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@Matricule", id);

            return oParameters;
        }

        public async Task<List<ClassTRH02Agent>> GetAgentBySubBranch(string id)
        {
            oItemList = new List<ClassTRH02Agent>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTRH02Agent>("Ps_TRH02AgentBySbBranch", this.RenseignerPrmSubBranch(id), commandType: CommandType.StoredProcedure);


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }


            }

            return oItemList;

        }

        private DynamicParameters RenseignerPrmSubBranch(string id)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@SBranchID", id);

            return oParameters;
        }

        public async Task<List<ClassTRH02Agent>> GetAgentByMatriculeCongeReq(ParamAgentMatricule param)
        {
            List<ClassTRH02Agent> agentList = new List<ClassTRH02Agent>();

            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();

                    agentList = (await oCon.QueryAsync<ClassTRH02Agent>(
                        "Ps_TRH02AgentByMatriculeCongReq",
                        this.RenseignerPrmCongeReq(param),
                        commandType: CommandType.StoredProcedure
                    )).ToList();
                }
            }
            catch (Exception ex)
            {
                // handle error
            }

            return agentList;
        }


        private DynamicParameters RenseignerPrmCongeReq(ParamAgentMatricule param)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@Matricule", param.Matricule);
            oParameters.Add("@UserID", param.UserID);
            return oParameters;

        }

        //============================

        public async Task<List<ClassTRH02Agent>> GetAgentByMatriculeXX(ParamAgentMatricule param)
        {

            string strQuery = string.Empty;

            if (param.RoleID == 2)
            {
                strQuery = "Ps_TRH02AgentByMatriculeCong";
            }
            else
            {
                strQuery = "Ps_TRH02AgentByMatricule";
            }


            List<ClassTRH02Agent> agentList = new List<ClassTRH02Agent>();

            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();

                    if (param.RoleID == 2)
                    {
                        agentList = (await oCon.QueryAsync<ClassTRH02Agent>("Ps_TRH02AgentByMatriculeCong", this.RenseignerPrmConge(param), commandType: CommandType.StoredProcedure)).ToList();

                    }
                    else
                    {
                        agentList = (await oCon.QueryAsync<ClassTRH02Agent>("Ps_TRH02AgentByMatricule", this.RenseignerPrmCongeMat(param), commandType: CommandType.StoredProcedure)).ToList();


                    }
                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return agentList;
        }


        private DynamicParameters RenseignerPrmConge(ParamAgentMatricule item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@Matricule", item.Matricule);
            oParameters.Add("@UserID", item.UserID);
            return oParameters;

        }

        private DynamicParameters RenseignerPrmCongeMat(ParamAgentMatricule item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@Matricule", item.Matricule);

            return oParameters;

        }

        public async Task<List<ClassTRH02Agent>> GetAgentByChef(ParamAgentByChef param)
        {

            string strQuery = string.Empty;

            if (param.RoleID == 2 && param.RoleID !=1)  // two is Chef
            {
                strQuery = "Ps_RechPersonneByChef";
            }
            else
            {
                strQuery = "Ps_RechPersonneBySBranchWithDG_HR";
            }

            oItemList = new List<ClassTRH02Agent>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTRH02Agent>(strQuery, this.RenseignerPrmRechByChef(param), commandType: CommandType.StoredProcedure);


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }


            }

            return oItemList;
        }

        private DynamicParameters RenseignerPrmRechByChef(ParamAgentByChef param)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@SBranch", param.SBranch);
            oParameters.Add("@ChefID", param.ChefID);

            return oParameters;
        }

        //=====================
    }
}

