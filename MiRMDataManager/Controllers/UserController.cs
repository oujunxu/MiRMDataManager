using Microsoft.AspNet.Identity;
using MiRM.Library.DataAccess;
using MiRM.Library.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MiRMDataManager.Controllers
{
    [Authorize]
    public class UserController: ApiController
    {
        [HttpGet] // a get call
        public UserModel GetById()
        {
            string userId = RequestContext.Principal.Identity.GetUserId(); // look up the user based on who they are.
            UserData data = new UserData();

            return data.GetUserById(userId).First();
        }

    }
}