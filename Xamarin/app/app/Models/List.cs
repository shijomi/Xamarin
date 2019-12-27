using System;
using System.Collections.Generic;
using System.Text;

namespace app.Models
{
    class List
    {
        internal object listID;
        internal object contact;

        public enum TypeContact
        {
            email,


        }
       
            public int ListID { get; set; }
            public string Name { get; set; }
            public TypeContact Type { get; set; }
        }


    }
}
