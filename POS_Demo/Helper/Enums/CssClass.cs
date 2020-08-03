using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POS_Demo.Helper.Enums
{
    public enum CssClass
    {
        [Display(Name = "kt-menu__item--open kt-menu__item--here")]
        Open,
        [Display(Name = "kt-menu__item--active")]
        Select
    }
}