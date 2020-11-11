using SnackHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackHouse.Repositories
{
    public interface ISnackRepository
    {
        //Ver todos os lanches
        ICollection<Snack> FindAll();

        ICollection<Snack> PreferSnacks();

        //Retornar lanche por Id
        Snack GetById(int snackId);
    }
}
