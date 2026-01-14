using PayLibrary.ListePaie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.PrimeAgentCom
{
    public interface IAgentComPrime
    {
        Task<List<AgentComPrime>> AgentComPrime(int Id);
    }
}
