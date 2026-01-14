using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace PayLibrary.InterfParamSec
{
    public interface ITSc551SubMenu
    {
        Task<List<TSc551SubMenu>> GetSubMenuList();
        Task<List<TSc551SubMenu>> GetListAll();
        Task<TSc551SubMenu> GetSubMenu(int id);
        Task<Resultat> GetUpdateResult(TSc551SubMenu item);

        Task<List<TSc551SubMenu>> GetFonctionMenu();
    }
}
