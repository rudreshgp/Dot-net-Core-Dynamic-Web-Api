using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DynamicProject.ViewModel;
using DynamicProject.Model;
using DynamicProject.BusinesManagerContracts;

namespace DynamicProject.BusinesService
{
    ///All webapi controllers should be attached to view model
    [Route("api/[controller]")]
    public class DynamicController<TViewModel,TModel>  : Controller where TViewModel:BaseViewModel, new() where TModel : class,new()
    {
        private IBusinessManager<TViewModel,TModel> _businessManager;
        public DynamicController(IBusinessManager<TViewModel,TModel> businessManager)
        {
            _businessManager = businessManager;
        }

        [HttpGet]
        public IEnumerable<TViewModel> Get()=> new List<TViewModel>
        {
            //TODO: Call Business Logic
            new TViewModel()  
        };

        [HttpPost]
        public bool Create([FromBody] TViewModel input)
        {
            //....
            return true;
        }

    }
}
