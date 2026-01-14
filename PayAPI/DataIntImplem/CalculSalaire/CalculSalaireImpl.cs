using Dapper;
using PayAPI.StringCon;
using PayLibrary.CalculSalaire;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.CalculSalaire
{
    public class CalculSalaireImpl : ICalculerSalaire
    {
        Resultat oResultat = new Resultat();

        public async Task<Resultat> PostArchiverSalaire(ParamCallSalaire item)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_ArchiverSalaireRIM", this.RenseignerPrmCalSal(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }

            return oResultat;

        }

        public async Task<Resultat> PostCalculerSalaire(ParamCallSalaire item)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_CalculSalairesRIM", this.RenseignerPrmCalSal(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }

            return oResultat;
        }



        private DynamicParameters RenseignerPrmCalSal(ParamCallSalaire item)

        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@Exercice", item.Exercice);
            oParameters.Add("@Mois", item.Mois);
            oParameters.Add("@UserID", item.UserID);

            return oParameters;

        }


    }
}
