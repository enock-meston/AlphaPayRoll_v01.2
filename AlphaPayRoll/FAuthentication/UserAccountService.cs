using System;
using System.Collections.Generic;
using System.Linq;

namespace AlphaPayRoll.FAuthentication
{
    public class UserAccountService
    {
        private List<UserAccount> UserAccountList;

        public UserAccountService()
        {

            UserAccountList = new List<UserAccount>
            {
                new UserAccount { UserName = @"DESKTOP-04I8BSF\User", Password = "admin123", Role = "Cashier" },
                new UserAccount { UserName = "user", Password = "user123", Role = "User"}

            };
        }

        public UserAccount? GetByUserName(string userName)
        {
            return UserAccountList.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
