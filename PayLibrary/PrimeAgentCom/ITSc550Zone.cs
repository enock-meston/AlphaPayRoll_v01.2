using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.PrimeAgentCom
{
	public interface ITSc550Zone
	{
		Task<List<TSc550Zone>> SupervisZone(int Id);
	}
}
