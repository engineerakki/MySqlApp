using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataObjects
{
    public class InterestData
    {
        public List<MonthlyData> Months { get; set; }
    }

    public class MonthlyData
    {
        public string MonthName { get; set; }
        public double Interest { get; set; }
    }
}