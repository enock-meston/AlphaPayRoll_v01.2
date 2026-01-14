using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PayLibrary.PlanningConge
{
    public interface ITHRPlanningConge
    {
        Task<List<THRPlanningConge>> GetAllPlanningConge();
        Task<List<THRPlanningConge>> GetPlanningCongeBySBranch(int SBranch);
        Task<List<THRPlanningConge>> GetPlanningCongeByMatricule(string id);
        Task<Resultat> UpdatePlanningConge(THRPlanningConge item);
        Task<Resultat> GetNumTranche(ParamNumTranche item);

    }
}
