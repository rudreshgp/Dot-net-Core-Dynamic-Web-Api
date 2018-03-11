using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DynamicProject.ViewModel;
using DynamicProject.Model;
using DynamicProject.BusinesManagerContracts;

namespace DynamicProject.BusinesService
{
    public class UserController : DynamicController<UserViewModel,User>
    {
        public UserController(IBusinessManager<UserViewModel,User> businessManager):base(businessManager)
        {
            
        }
    }
}