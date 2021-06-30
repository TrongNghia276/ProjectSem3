using ClinicServicesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicServicesWebAPI.DataConnect;

namespace ClinicServicesWebAPI.Services
{
    public class vCateCateChildServices : IvCateCateChild
    {
        private ClinicContext context;
        public vCateCateChildServices(ClinicContext context)
        {
            this.context = context;
        }
     

        public async Task<IEnumerable<vCateCateChild>> GetIvCateCateChild()
        {
            var a = from g in context.Categories
                    join c in context.CategoryChild
                    on g.CategoriesID equals c.CategoriesID
                    select new vCateCateChild { Categories = g, CategoryChild = c, KeyID = g.CategoriesID };
            return a.ToList();
        }

      
    }
}
