using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POS_Demo.DataModels.Common
{
    public class AuditableEntity
    {

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }

        [Display(Name = "Created Data")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public System.DateTime Created { get; set; }

        [Display(Name = "Modified By")]
        public int LastModifiedBy { get; set; }

        [Display(Name = "Modified Data")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public System.DateTime LastModified { get; set; }

    }
}