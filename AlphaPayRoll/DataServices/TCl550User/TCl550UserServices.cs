using Microsoft.AspNetCore.Components;
using PayLibrary.TCl550User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TCl550User
{
    public class TCl550UserServices
    {
        public class TCl550UserService : ITCl550User
        {
            private readonly HttpClient oHttpClient;

            public TCl550UserService(HttpClient httpClient)
            {
                oHttpClient = httpClient;
            }


            public async Task<List<ClassTCl550User>> GetTCl550User()
            {
                return (await oHttpClient.GetJsonAsync<ClassTCl550User[]>($"api/TCl550User/")).ToList();
            }
        }
    }
}
