using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Contract.Request
{
    public class UserUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string surName { get; set; }
        public string Email { get; set; }
 
   
    }
}
