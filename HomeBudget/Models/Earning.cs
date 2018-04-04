using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeBudget.Models
{
    public class Earning
    {
        private Account _account = new Account();
        public Earning()
        {

        }
        public int Id { get; set; }
        public Category CategoryName { get; set; }
        public double Income { get; set; }
        public DateTime DateTime { get; set; }
        public string EarningNote { get; set; }


    }
}