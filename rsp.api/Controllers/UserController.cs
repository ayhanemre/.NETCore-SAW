using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace rsp.api.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private IBaseService<User,Guid> service;
        public UserController(IBaseService<User,Guid> pService)
        {
            this.service = pService;
        }

        [HttpGet]
        public ICollection<User> find(){
            return this.service.find();
        }
    }

}