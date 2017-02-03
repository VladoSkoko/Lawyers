using Lawyers.SupplementalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.Entities
{
    public partial class Lawyer
    {
        public static List<Lawyer> GetLawyers()
        {
            try
            {
                using (var db = new LawyersEntities())
                {
                    return db.Lawyers.OrderBy(x => x.Name).ToList();
                }
            }
            catch
            {
                throw;
            }
        }

        private static bool Validate(Lawyer Lawyer)
        {
            try
            {
                EntryValidation v = new EntryValidation();
                v.AddIfEmpty(Lawyer.Name, "Name");
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
                    db.Lawyers.Attach(this);
                    db.Lawyers.Add(this);
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
