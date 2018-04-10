﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class EarningCategory : Category
    {
       
        public new virtual ICollection<EarningSubCategory> Subcategories { get; set; }
    }
}