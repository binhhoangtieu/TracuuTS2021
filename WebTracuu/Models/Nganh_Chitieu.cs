using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTracuu.Models
{
    public class Nganh_Chitieu
    {
        public string Nganh { get; set; }
        public int ChiTieu { get; set; }
        public int Ngoai_SP { get; set; }
        public string Dean_TS { get; internal set; }
    }
}