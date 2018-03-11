using System;
using System.Collections.Generic;
using DynamicProject.BusinesManagerContracts;
using DynamicProject.Model;
using DynamicProject.RepositoryContracts;
using DynamicProject.ViewModel;
using DynamicProject.ViewModel.Helper;

namespace DynamicProject.BusinesManager
{
    public class BusinessManager<TViewModel, TModel> : IBusinessManager<TViewModel, TModel>  where TViewModel:class ,new() where TModel:BaseModel,new()
    {
        private ICrudRepository<TModel> _repository;
        public BusinessManager(ICrudRepository<TModel> repository)
        {
            _repository = repository;
        }
        ///Get all items in the table
        public List<TViewModel> GetAll()
        {
            var objects =  _repository.GetAll();
            var responseList = new List<TViewModel>();
            objects.ForEach(x=>{
                //TODO:Use Auto mapper
                responseList.Add(new TViewModel());
            });
            return responseList;
        }
        public TViewModel Create(TViewModel newObject)
        {
            var createdObject = _repository.Create(new TModel());
            // ((BaseViewModel)newObject).Id = createdObject.Id;
            return newObject;
        }

       ///Get all items with some search condition
        public List<TViewModel> GetAll(SearchParameterViewModel searchParameters)
        {
            throw new NotImplementedException();
        }

        ///Get object by Id
        public TViewModel Get(int id)
        {
            var model = _repository.Get(id);
            return new TViewModel();
        }

        ///Update existing object and return the status       
        public int Update(TViewModel UpdateObject)
        {
            throw new NotImplementedException();
        }

        ///Delete existing objects by ids(Multiple deletion) 
        public bool Delete(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
