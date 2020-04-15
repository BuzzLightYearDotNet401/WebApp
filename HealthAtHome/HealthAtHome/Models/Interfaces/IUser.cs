using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HealthAtHome.Models.Interfaces
{
    public interface IUser
    {
        Task<User> GetUser();
        Task<HttpResponseMessage> RegisterUser(User user);
        Task<HttpResponseMessage> LogIn(User user);
    }
}
