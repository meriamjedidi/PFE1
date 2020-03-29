using PFE1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE1.Repository
{
   public  interface IPersonnelRepository
    {
        IEnumerable<Personnel> GetAll();
        Personnel Get(int Id);
        string Add(Personnel entity);
        string Update(int Id, Personnel entity);
        string Delete(int Id);
    }
}

