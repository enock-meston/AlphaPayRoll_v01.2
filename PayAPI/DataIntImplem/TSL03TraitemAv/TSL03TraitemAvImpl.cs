using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL03TraitemAv;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataImplementation.TSL03TraitemAv
{
    public class TSL03TraitemAvImpl : ITSL03TraitemAv
    {

        List<ClassTSL03TraitemAv> oItemList = new List<ClassTSL03TraitemAv>();

        Resultat oResultat = new Resultat();


        public async Task<List<ClassTSL03TraitemAv>> GetTSL03TraitemAv()
        {
            oItemList = new List<ClassTSL03TraitemAv>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTSL03TraitemAv>("Select * from TSL03TraitemAv");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }


            }

            return oItemList;
        }


        public async Task<Resultat> GetResutUpdate(ClassTSL03TraitemAv item)
        {

            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSL03TraitemAv", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(ClassTSL03TraitemAv item)

        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@ID", item.ID);
            oParameters.Add("@An", item.An);
            oParameters.Add("@Mois", item.Mois);
            oParameters.Add("@AgentId", item.AgentId);
            oParameters.Add("@SalBase", item.SalBase);
            oParameters.Add("@Logem", item.Logem);
            oParameters.Add("@Deplacem", item.Deplacem);
            oParameters.Add("@HeureSup", item.HeureSup);
            oParameters.Add("@Alloc", item.Alloc);
            oParameters.Add("@Indemnit", item.Indemnit);
            oParameters.Add("@IndemRep", item.IndemRep);
            oParameters.Add("@AutresIndmt", item.AutresIndmt);
            oParameters.Add("@Brut", item.Brut);
            oParameters.Add("@BaseIPR", item.BaseIPR);
            oParameters.Add("@AvancQuinz", item.AvancQuinz);
            oParameters.Add("@Unif", item.Unif);
            oParameters.Add("@AssAcc", item.AssAcc);
            oParameters.Add("@AssInc", item.AssInc);
            oParameters.Add("@AssVeh", item.AssVeh);
            oParameters.Add("@PensionCompl", item.PensionCompl);
            oParameters.Add("@AssEducEnf", item.AssEducEnf);
            oParameters.Add("@AssPensCom", item.AssPensCom);
            oParameters.Add("@CotisEdEnf", item.CotisEdEnf);
            oParameters.Add("@AssSRD", item.AssSRD);
            oParameters.Add("@CredVeh", item.CredVeh);
            oParameters.Add("@CredFPHU", item.CredFPHU);
            oParameters.Add("@CredBICOR", item.CredBICOR);
            oParameters.Add("@AvancAnnuel", item.AvancAnnuel);
            oParameters.Add("@AvancPonct", item.AvancPonct);
            oParameters.Add("@AvancEduc", item.AvancEduc);
            oParameters.Add("@AvanceMatSco", item.AvanceMatSco);
            oParameters.Add("@CaisseSoc", item.CaisseSoc);
            oParameters.Add("@ContriElec", item.ContriElec);
            oParameters.Add("@ContriCaisSport", item.ContriCaisSport);
            oParameters.Add("@FraisMedic", item.FraisMedic);
            oParameters.Add("@INSS", item.INSS);
            oParameters.Add("@IPR", item.IPR);
            oParameters.Add("@TotRetenus", item.TotRetenus);
            oParameters.Add("@NETS", item.NETS);
            oParameters.Add("@NbreHS", item.NbreHS);
            oParameters.Add("@NbreJTrav", item.NbreJTrav);
            oParameters.Add("@PPINSS6", item.PPINSS6);
            oParameters.Add("@PPINSS3", item.PPINSS3);
            oParameters.Add("@PPPens", item.PPPens);
            oParameters.Add("@TempDec", item.TempDec);
            oParameters.Add("@NonVie", item.NonVie);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);


            return oParameters;

        }

    }
}

