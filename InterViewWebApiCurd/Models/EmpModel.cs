using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterViewWebApiCurd.Models
{
    public class EmpModel
    {
        public int id { get; set; }
        public int Emp_code { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
    }
}