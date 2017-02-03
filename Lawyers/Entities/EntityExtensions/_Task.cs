using Lawyers.SupplementalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.Entities
{
    public partial class Task
    {
        public static List<Task> GetTasks()
        {
            using (var db = new LawyersEntities())
            {
                return db.Tasks.OrderBy(x => x.Date).ToList();
            }
        }

        public static List<sp_GetAllTasks_Result> GetTasksWithInfo()
        {
            using (var db = new LawyersEntities())
            {
                return db.sp_GetAllTasks().OrderBy(x => x.CompanyName).ToList();
            }
        }

        private static bool Validate(Task Task)
        {
            try
            {
                EntryValidation v = new EntryValidation();
                //v.AddIfEmpty(Task.BillableTime, "Billable time");
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
                    db.Tasks.Attach(this);
                    db.Tasks.Add(this);
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
