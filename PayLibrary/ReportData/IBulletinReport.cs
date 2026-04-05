using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ReportData
{
    public interface IBulletinReport
    {
        Task<BulletinReport> GetBulletinReport(string Exercice, string Mois, string Matricule);
    }
}
