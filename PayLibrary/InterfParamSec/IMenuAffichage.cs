using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.InterfParamSec
{
    public interface IMenuAffichage
    {
        
        Task<MenuAffichage> GetMenuFonctOne(int id);
        Task<List<MenuAffichage>> GetMenuFonctList(string id);
        //Task<List<MenuAffichage>> GetFonctionMenu();

        //Task<MenuAffichage> GetMenuFonctTwo(int id);
    }
}
