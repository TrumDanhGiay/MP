using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP.Models
{
    public class MenuChild
    {
        public string MenuName { get; set; }

        public List<String> ChildMenu { get; set; }
    }

}