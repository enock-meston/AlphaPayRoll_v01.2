using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayLibrary.TRH550TypeSalaire
{
    public interface ITRH550TypeSalaire
    {
        Task<List<TRH550TypeSalaire>> GetAllTypeSalaire();
    }
}
