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
        public IEnumerable<TViewModel> GetAll()
        {
            try
            {
                return _businessManager.GetAll();
            }
            catch(Exception ex)
            {
                    throw;
            }
        }

        [HttpPost]
        public TViewModel Create([FromBody] TViewModel input)
        {
            try
            {
                return _businessManager.Create(input);
            }
            catch(Exception ex)
            {
                    throw;
            }
        }

    }
}
