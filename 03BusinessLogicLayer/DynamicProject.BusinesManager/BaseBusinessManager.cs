using System;
using System.Collections.Generic;
using DynamicProject.BusinesManagerContracts;
using DynamicProject.RepositoryContracts;
using DynamicProject.ViewModel.Helper;

namespace DynamicProject.BusinesManager
{
    public class BaseBusinessManager<TViewModel, TModel> : IBaseBusinessManager<TViewModel, TModel>  where TViewModel:class ,new() where TModel:class,new()
    {
        private ICrudRepository _repository;
        public BaseBusinessManager(ICrudRepository repository)
        {
            _repository = repository;
        }
        ///Get all items in the table
       TableListViewModel<TViewModel> IBaseBusinessManager<TViewModel, TModel>.GetAll()
        {
            throw new NotImplementedException();
        }


       ///Get all items with some search condition
        TableListViewModel<TViewModel> IBaseBusinessManager<TViewModel, TModel>.GetAll(SearchParameterViewModel searchParameters)
        {
            throw new NotImplementedException();
        }

        ///Get object by Id
        TViewModel IBaseBusinessManager<TViewModel, TModel>.Get(int id)
        {
            throw new NotImplementedException();
        }

        ///Update existing object and return the status       
        int IBaseBusinessManager<TViewModel, TModel>.Update(TViewModel UpdateObject)
        {
            throw new NotImplementedException();
        }

        ///Delete existing objects by ids(Multiple deletion) 
        bool IBaseBusinessManager<TViewModel, TModel>.Delete(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
