using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        static BusinessManager()
        {
            Mapper.Initialize(x=>
            {
                x.CreateMap<TViewModel,TModel>();
                x.CreateMap<TModel,TViewModel>();
            }            );
        }
        ///Get all items in the table
        public async Task<List<TViewModel>> GetAll()
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
            //TODO:Auto mapper
            var model = Mapper.Map<TViewModel,TModel>(newObject);
            this.MapAuditColumns(model);
            model = _repository.Create(model);
            // ((BaseViewModel)newObject).Id = createdObject.Id;
            newObject = Mapper.Map<TModel,TViewModel>(model);
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
        private void MapAuditColumns(TModel model)
        {
            
            var baseModel = model as BaseModel;
            if(baseModel!=null)
            {
                if(baseModel.Id==0)
                {
                    baseModel.CreatedAt = DateTime.UtcNow;
                    baseModel.CreatedBy ="";
                }
                baseModel.ModifiedAt = DateTime.UtcNow;
                baseModel.ModifiedBy = "";
            }
        }
    }
}
