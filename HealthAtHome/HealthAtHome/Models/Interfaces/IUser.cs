using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HealthAtHome.Models.Interfaces
{
    public interface IUser
    {
        /// <summary>
        /// Get a user from the DB.
        /// </summary>
        /// <returns>A user.</returns>
        Task<User> GetUser();

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="user">The user to register.</param>
        /// <returns>Success or fail.</returns>
        Task<HttpResponseMessage> RegisterUser(User user);

        /// <summary>
        /// Logs in an existing user.
        /// </summary>
        /// <returns>success or fail.</returns>
        Task<List<User>> LogIn();

        /// <summary>
        /// Deletes a user from a DB.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> DeleteUser(int userId);
    }
}
