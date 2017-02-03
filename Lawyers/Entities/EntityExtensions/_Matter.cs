using Lawyers.SupplementalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.Entities
{
    public partial class Matter
    {
        public static List<Matter> GetMatters()
        {
            using (var db = new LawyersEntities())
            {
                return db.Matters.OrderBy(x => x.Name).ToList();
            }
        }

        public static List<Matter> GetMattersByCompanyID(int CompanyID)
        {
            using (var db = new LawyersEntities())
            {
                return db.Matters.Where(x => x.CompanyID == CompanyID).OrderBy(x => x.Name).ToList();
            }
        }

        private static bool Validate(Matter Matter)
        {
            try
            {
                EntryValidation v = new EntryValidation();
                v.AddIfEmpty(Matter.Name, "Name");
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
                    db.Matters.Attach(this);
                    db.Matters.Add(this);
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
