//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FitnessFlex
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fee
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> PaidDate { get; set; }
        public string FeePlan { get; set; }
        public System.DateTime From { get; set; }
        public System.DateTime To { get; set; }
        public int Mon { get; set; }
        public Nullable<int> MonthlyFeeTotal { get; set; }
        public Nullable<int> PrevDues { get; set; }
        public Nullable<int> PersonalTrainerFee { get; set; }
        public Nullable<int> AdmissionFee { get; set; }
        public Nullable<int> NetTotal { get; set; }
        public Nullable<int> Adjustment { get; set; }
        public Nullable<int> ToBePaid { get; set; }
        public Nullable<int> Paid { get; set; }
        public Nullable<int> FeeBalance { get; set; }
        public int MemberID { get; set; }
    
        public virtual Member Member { get; set; }
    }
}
