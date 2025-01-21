using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Entities
{
    public class UserEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserEntity(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
