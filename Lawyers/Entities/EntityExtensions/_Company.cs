using Lawyers.SupplementalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.Entities
{
    public partial class Company
    {
        public static List<Company> GetCompanies()
        {
            using (var db = new LawyersEntities())
            {
                return db.Companies.OrderBy(x => x.Name).ToList();
            }
        }

        private static bool Validate(Company Company)
        {
            try
            {
                EntryValidation v = new EntryValidation();
                v.AddIfEmpty(Company.Name, "Name");
                if (v.HasErrors())
                {
                    v.PrintErrors();
                    return false;
                }
            }
            catch
            {
                throw;
            }
            return true;
        }

        public void Add()
        {
            try
            {
                using (var db = new LawyersEntities())
                {
                    db.Companies.Attach(this);
                    db.Companies.Add(this);
                    db.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
