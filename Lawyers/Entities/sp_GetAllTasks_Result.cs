//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lawyers.Entities
{
    using System;
    
    public partial class sp_GetAllTasks_Result
    {
        public int TaskID { get; set; }
        public string TaskDescription { get; set; }
        public int TaskBillableTime { get; set; }
        public System.DateTime TaskDate { get; set; }
        public Nullable<int> LawyerID { get; set; }
        public string LawyerName { get; set; }
        public Nullable<int> SubmatterID { get; set; }
        public string SubmatterName { get; set; }
        public Nullable<int> MatterID { get; set; }
        public string MatterName { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string CompanyName { get; set; }
    }
}
