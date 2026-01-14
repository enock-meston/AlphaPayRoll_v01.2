using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Components.Pages.Personnel_RIM2
{
    public class AutoIncrementID
    {
        private string prefix;
        private int currentNumber;

        public AutoIncrementID(string prefix, int oOnePersonnel_RIM2 = 0)
        {
            this.prefix = prefix;
            this.currentNumber= oOnePersonnel_RIM2;
        }

        public string GenerateID()
        {
            currentNumber++;
            string formattedNumber = currentNumber.ToString("D5");
            return prefix + formattedNumber;
        }
    }
}
