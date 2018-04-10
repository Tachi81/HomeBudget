﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class ExpenseSubCategory : SubCategory
    {
      
        public new virtual ExpenseCategory Category { get; set; }
    }
}