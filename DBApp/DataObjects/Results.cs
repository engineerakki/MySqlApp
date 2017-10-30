using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace  DataObjects
{
    public class Results
    {
        public DateTime Created { get; set; }
        public List<MonthlyData> Months { get; set; }
        public double Balance { get; set; }
        public double NewBalance { get; set; }
        public double Deposit { get; set; }
    }
}