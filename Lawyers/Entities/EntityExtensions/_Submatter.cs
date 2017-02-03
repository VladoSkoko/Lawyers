using Lawyers.SupplementalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.Entities
{
    public partial class Submatter
    {
        public static List<Submatter> GetSubmatters()
        {
            using (var db = new LawyersEntities())
            {
                return db.Submatters.OrderBy(x => x.Name).ToList();
            }
        }

        public static List<Submatter> GetSubmattersByMatterID(int MatterID)
        {
            using (var db = new LawyersEntities())
            {
                return db.Submatters.Where(x => x.MatterID == MatterID).OrderBy(x => x.Name).ToList();
            }
        }

        private static bool Validate(Submatter Submatter)
        {
            try
            {
                EntryValidation v = new EntryValidation();
                v.AddIfEmpty(Submatter.Name, "Name");
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
                    db.Submatters.Attach(this);
                    db.Submatters.Add(this);
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
