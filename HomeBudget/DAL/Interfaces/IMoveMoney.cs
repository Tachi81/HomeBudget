using System;

namespace HomeBudget.DAL.Interfaces
{
    public interface IMoveMoney
    {
         DateTime DateTime { get; set; }
         string Note { get; set; }
    }
}