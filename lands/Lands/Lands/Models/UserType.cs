using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Models
{
    public class UserType {
 
        public int UserTypeId { get; set; }


        public string Name { get; set; }

  
        public virtual ICollection<User> Users { get; set; }
    }
}
