using AspNetCore.Reporting;
using Dapper;
using Microsoft.Extensions.Configuration;
using PayLibrary.ListePaie;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PayAPI.RepServices
{

    public interface IPayrollListRIPPSService
    {
        Task<byte[]> GenerateListRIPPSAsync(string reportName, string reportType);


    }
    public class PayrollListRIPPSService : IPayrollListRIPPSService
    {
        private readonly string connectionString;
        public PayrollListRIPPSService(IConfiguration configuratrion)
        {
            connectionString = configuratrion.GetConnectionString("ApiConnection")!;
        }

        List<ListPayRIPPS> itemList = new List<ListPayRIPPS>();

        public object ClassConString { get; private set; }

        public async Task<byte[]> GenerateListRIPPSAsync(string reportName, string reportType)
        {

            string RepfilePath = Assembly.GetExecutingAssembly().Location.Replace("PayAPI.dll", string.Empty); ;
            string rdlcfilePath = string.Format("{0}ReportFiles\\{1}.rdlc", RepfilePath, reportName);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");
            LocalReport rdlcReport = new LocalReport(rdlcfilePath);

            using (IDbConnection oCon = new SqlConnection(connectionString))
            {

                if (oCon.State == ConnectionState.Closed) oCon.Open();


                var List = await oCon.QueryAsync<ListPayRIPPS>("Ps_ListPayRIPPS", commandType: CommandType.StoredProcedure); ;

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }

            rdlcReport.AddDataSource("dsPayrollRIPPS", itemList);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            var result = rdlcReport.Execute(GetRenderType(reportType), 1, parameter);

            return result.MainStream;
        }



        private RenderType GetRenderType(string reportType)
        {
            var renderType = RenderType.Pdf;
            switch (reportType.ToUpper())
            {
                default:
                case "PDF":
                    renderType = RenderType.Pdf;
                    break;
                case "XLS":
                    renderType = RenderType.Excel;
                    break;
                case "WORD":
                    renderType = RenderType.Word;
                    break;
            }

            return renderType;
        }


    }
}

