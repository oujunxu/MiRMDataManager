using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiRMDesktopUI.Library.Models
{
    /*
     WPF uses this model to access the data which the api sends out.
    Even though this model is the same as UserModel, they aren't the same. This is for displaying data whereas the other is used for save data.
     */
    public class LoggedInUserModel : ILoggedInUserModel
    {
        public string Token { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
