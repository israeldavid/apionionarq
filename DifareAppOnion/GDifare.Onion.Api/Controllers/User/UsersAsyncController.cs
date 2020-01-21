using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.IServices.RequestAggregate.Async;

namespace OnionPattern.Api.Controllers.User
{

    /// <inheritdoc />
    /// <summary>
    /// usuarios Controller
    /// </summary>
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersAsyncController : BaseAsyncController
    {
        private readonly IUserRequestAggregateAsync UserRequestAggregateAsync;

        /// <inheritdoc />
        /// <summary>
        /// Video Games Controller
        /// </summary>
        /// <param name="userRequestAggregateAsync"></param>
        public UsersAsyncController(IUserRequestAggregateAsync userRequestAggregateAsync)
        {
            UserRequestAggregateAsync = userRequestAggregateAsync ?? throw new ArgumentNullException(nameof(userRequestAggregateAsync));
        }
        /// <summary>
        /// Get a list of all games.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> Get()
        {
            return await ExecuteAndHandleRequestAsync(() => UserRequestAggregateAsync.GetAllUsersRequestAsync.ExecuteAsync());
        }
    }
}
