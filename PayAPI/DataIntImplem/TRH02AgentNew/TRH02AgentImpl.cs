using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TRH02AgentNew;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using Microsoft.Extensions.Logging;

namespace PayAPI.DataImplementation.TRH02AgentNew
{

    public class TRH02AgentImpl : ITRH02Agent

    {

        List<ClassTRH02Agent> oItemList = new List<ClassTRH02Agent>();

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
            oParameters.Add("@DateNais", item.DateNais);//====
            oParameters.Add("@Sexe", item.Sexe);//====
            oParameters.Add("@EtatCivId", item.EtatCivId);
            oParameters.Add("@NbrepCharge", item.NbrepCharge);
            oParameters.Add("@BranchId", item.BranchLocID);
            oParameters.Add("@DepartementId", item.DepartementId);
            oParameters.Add("@FonctionId", item.FonctionId);///====
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
            // Names must match [dbo].[Ps_TRH02AgentSalaire] exactly (SQL Server is usually case-insensitive; keep same casing as DB).
            oParameters.Add("@AgentID", item.AgentId);
            oParameters.Add("@ClientId", item.ClientId);
            oParameters.Add("@Nom", item.Nom);
			oParameters.Add("@Prenom", item.Prenom);
            oParameters.Add("@SBranchLocId", item.SBranchLocID);
			oParameters.Add("@SBranchCpteId", item.SBranchCpteID);
			oParameters.Add("@StatusId", item.StatusId);
            oParameters.Add("@PayDay", item.PayDay);
            oParameters.Add("@SalBase", item.SalBase);
			oParameters.Add("@IndemLog", item.IndemLog);
			oParameters.Add("@IndemDeplac", item.IndemDeplac);
			oParameters.Add("@IndemFct", item.IndemFct);
			oParameters.Add("@IndemAutre", item.IndemAutre);
			oParameters.Add("@AutresAvantage", item.AutresAvantage);
			oParameters.Add("@RembCredit", item.RembCredit);
			oParameters.Add("@RembBourse", item.RembBourse);
			oParameters.Add("@RetSanLam", item.RetSanLam);
			oParameters.Add("@RetPrimeLife", item.RetPrimeLife);
			oParameters.Add("@RetCaisseSolid", item.RetCaisseSolid);
			oParameters.Add("@RetCaisEp", item.RetCaisEp);
			oParameters.Add("@RetEjoHeza", item.RetEjoHeza);
			oParameters.Add("@AutRetenues", item.AutRetenues);
			oParameters.Add("@Matricule", item.Matricule);
			oParameters.Add("@Gratifications", item.Gratifications);
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


    }
}

