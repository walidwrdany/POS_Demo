//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS_Demo.DataModels
{
    using POS_Demo.DataModels.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Sales_Person : AuditableEntity
    {

        public Sales_Person()
        {
            this.Sales_Person_Slab = new HashSet<Sales_Person_Slab>();
            this.Units_Details = new HashSet<Units_Details>();
        }

        [Display(Name = "Salesman Code")]
        [DisplayFormat(DataFormatString = "{0:D5}", ApplyFormatInEditMode = true)]
        public int Id { get; set; }

        [Display(Name = "Salesman Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }


        public virtual ICollection<Sales_Person_Slab> Sales_Person_Slab { get; set; }

        public virtual ICollection<Units_Details> Units_Details { get; set; }
    }
}
