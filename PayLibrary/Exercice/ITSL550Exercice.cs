using PayLibrary.Exercice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.Exercice
{
    public interface ITSL550Exercice
    {
        Task<List<TSL550Exercice>> GetExerciceAll();
    }
}
