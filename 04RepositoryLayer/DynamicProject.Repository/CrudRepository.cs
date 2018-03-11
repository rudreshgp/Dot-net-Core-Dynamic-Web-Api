using System;
using System.Collections.Generic;
using System.Linq;
using DynamicProject.Model;
using DynamicProject.RepositoryContracts;
namespace DynamicProject.Repository
{
    public class CrudRepository<TModel> : ICrudRepository<TModel> where TModel : BaseModel
    {
        private static List<TModel> _tempList =new List<TModel>();
        public TModel Create(TModel model)
        {
            // throw new NotImplementedException();
            _tempList.Add(model);
            model.Id = _tempList.Count;
            return model;
        }

        public TModel Get(int id)
        {
            return _tempList.FirstOrDefault(x=>x.Id==id);
        }

        public List<TModel> GetAll()
        {
            return _tempList;
        }
    }
}
