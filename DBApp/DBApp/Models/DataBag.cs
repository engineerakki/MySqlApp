using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBApp.Models
{
    public class DataBag
    {
        public List<MonthlyData> Interest { get; set; }
        public Results WhatIfResults { get; set; }
        public AccountData Account { get; set; }
    }
}