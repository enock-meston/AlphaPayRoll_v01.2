
using AlphaPayRoll.StringCon;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using PayLibrary.ListePaie;
using System.Linq;
using Dapper;

namespace AlphaPayRoll.ReportService
{
    public class ClasListePayConsolidService
    {

        public  DataTable GetListePayConsolidInfo(int id)
        {

            string stringSQL = "SELECT ROW_NUMBER() over(order by TSc550Branch.Descript, " +
            "TSc551SubBranch.Descript,Matricule) as Numero,   TSc550Branch.Descript AS Branch, " +
            "TSc551SubBranch.Descript AS SubBranch, TRH02Agent.Matricule, Code, rtrim(TRH02Agent.Nom)+' '+rtrim(TRH02Agent.Prenom) as Noms, " +
            "TRH02Agent.SalBase, TRH02Agent.IndemLog, TRH02Agent.IndemDeplac, " +
            "TRH02Agent.IndemFct, TRH02Agent.Gratifications, TRH02Agent.TotalIndem, TRH02Agent.Primes, " +
            "TRH02Agent.SALAIRE_BRUT, TRH02Agent.TPR,  AutresAvantage,SALAIRE_IMPOSABLE,Cotisation_Patronale, " +
            "Cotisation_Caisse_Social,RSSB_EMPLOYEUR,RSSB_EMPLOYEE, MutSante,AutRetenues,TotalReteNonStat,  " +
            "TotalRetenue,TRH02Agent.NetAPayer,GetDate() as DateJ " +
            "FROM   TRH02Agent INNER JOIN " +
            "TSc551SubBranch ON TRH02Agent.BranchId = TSc551SubBranch.ID INNER JOIN " +
            "TSc550Branch ON TSc551SubBranch.CodeBranch = TSc550Branch.ID ";




            List<LstPaieConsolid> itemList = new List<LstPaieConsolid>();


            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = oCon.Query<LstPaieConsolid>(stringSQL);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }



            var dt = new DataTable();

            dt.Columns.Add("Numero");
            dt.Columns.Add("Branch");
            //dt.Columns.Add("Matricule");
            dt.Columns.Add("Matricule");
            //dt.Columns.Add("Code");
            dt.Columns.Add("Noms");
            dt.Columns.Add("SalBase");
            dt.Columns.Add("IndemLog");
            dt.Columns.Add("IndemDeplac");
            dt.Columns.Add("IndemFct");
            dt.Columns.Add("Gratifications");
            dt.Columns.Add("TotalIndem");
            dt.Columns.Add("Primes");
            dt.Columns.Add("SALAIRE_BRUT");
            dt.Columns.Add("TPR");
            dt.Columns.Add("AutresAvantage");
            dt.Columns.Add("SALAIRE_IMPOSABLE");
            dt.Columns.Add("Cotisation_Patronale");
            dt.Columns.Add("Cotisation_Caisse_Social");
            dt.Columns.Add("RSSB_EMPLOYEUR");
            dt.Columns.Add("RSSB_EMPLOYEE");
            dt.Columns.Add("MutSante");
            dt.Columns.Add("AutRetenues");
            dt.Columns.Add("TotalReteNonStat");
            dt.Columns.Add("TotalRetenue");
            dt.Columns.Add("NetAPayer");
            dt.Columns.Add("DateJ");

            DataRow dr;


            for (int i = 0; i < itemList.Count; i++)
            {
                dr = dt.NewRow();

                dr["Numero"] = itemList[i].Numero;
                dr["Branch"] = itemList[i].Branch;
                dr["Matricule"] = itemList[i].SubBranch;
                //dr["Matricule"] = itemList[i].Matricule;
                //dr["Code"] = itemList[i].Code;
                dr["Noms"] = itemList[i].Noms;
                dr["SalBase"] = itemList[i].SalBase;
                dr["IndemLog"] = itemList[i].IndemLog;
                dr["IndemDeplac"] = itemList[i].IndemDeplac;
                dr["IndemFct"] = itemList[i].IndemFct;
                dr["Gratifications"] = itemList[i].Gratifications;
                dr["TotalIndem"] = itemList[i].TotalIndem;
                dr["Primes"] = itemList[i].Primes;
                dr["SALAIRE_BRUT"] = itemList[i].SALAIRE_BRUT;
                dr["TPR"] = itemList[i].TPR;
                dr["AutresAvantage"] = itemList[i].AutresAvantage;
                dr["SALAIRE_IMPOSABLE"] = itemList[i].SALAIRE_IMPOSABLE;
                dr["Cotisation_Patronale"] = itemList[i].Cotisation_Patronale;
                dr["Cotisation_Caisse_Social"] = itemList[i].Cotisation_Caisse_Social;
                dr["RSSB_EMPLOYEUR"] = itemList[i].RSSB_EMPLOYEUR;
                dr["RSSB_EMPLOYEE"] = itemList[i].RSSB_EMPLOYEE;
                dr["MutSante"] = itemList[i].MutSante;
                dr["AutRetenues"] = itemList[i].AutRetenues;
                dr["TotalReteNonStat"] = itemList[i].TotalReteNonStat;
                dr["TotalRetenue"] = itemList[i].TotalRetenue;
                dr["NetAPayer"] = itemList[i].NetAPayer;
                dr["DateJ"] = itemList[i].DateJ.ToShortDateString();


                dt.Rows.Add(dr);
            }

            return dt;

        }




    }
}


