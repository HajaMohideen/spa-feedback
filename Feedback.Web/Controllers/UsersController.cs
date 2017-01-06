using AutoMapper;
using Feedback.Data.Infrastructure;
using Feedback.Data.Repositories;
using Feedback.Entities;
using Feedback.Web.Infrastructure.Core;
using Feedback.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Feedback.Web.Infrastructure.Extensions;
using Feedback.Data.Extensions;

namespace Feedback.Web.Controllers
{
    [Authorize(Roles="Admin")]
    [RoutePrefix("api/users")]
    public class UsersController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Users> _usersRepository;

        public UsersController(IEntityBaseRepository<Users> usersRepository, 
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _usersRepository = usersRepository;
        }
        
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, UsersViewModel user)
        {

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                Users newUsers = new Users();
                newUsers.UpdateUsers(user);
                _usersRepository.Add(newUsers);

                _unitOfWork.Commit();

                // Update view model
                user = Mapper.Map<Users, UsersViewModel>(newUsers);
                response = request.CreateResponse<UsersViewModel>(HttpStatusCode.Created, user);

                return response;
            });
        }
        
    }
}
