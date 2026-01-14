using PayLibrary.GetHRCounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.GetUserCounts
{
    public interface IClassGetAgentCounts
    {
        Task<List<ClassGetAgentCounts>> GetAgentCountsAsync(string id);

    }
}
