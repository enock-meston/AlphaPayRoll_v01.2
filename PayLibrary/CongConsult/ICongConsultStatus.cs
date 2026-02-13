using PayLibrary.CongeRequestF;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.CongConsult
{
    public interface ICongConsultStatus
    {
        Task<List<CongConsultStatus>> GetAllCongeConsultStatus(string id);
    }
}
