using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public enum TypeContact
    { email,
           
    }
    public class List
    {
        public int ListID { get; set; }
        public string Name { get; set; }
       public TypeContact Type { get; set; }
    }
}