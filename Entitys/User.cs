using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
 
        public class User
        {
            public int UserId { get; set; }
            [EmailAddress, Required]
            public string UserEmail { get; set; }
            public string UserFirstName { get; set; }
            public string UserLastName { get; set; }
            [StringLength(maximumLength: 20, ErrorMessage = "הסיסמה חייבת להיות בין 4 ל-20 תווים"), MinLength(4)]
            public string UserPassword { get; set; }
        }

        public class LoginUser
        {
            public string LoginUserEmail { get; set; }
            public string LoginUserPassword { get; set; }
        }
    
}
