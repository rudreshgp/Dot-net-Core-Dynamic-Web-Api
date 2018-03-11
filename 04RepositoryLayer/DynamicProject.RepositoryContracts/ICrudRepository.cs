using System;
using System.Collections.Generic;
using DynamicProject.Model;

namespace DynamicProject.RepositoryContracts
{
    public interface ICrudRepository<TModel> where TModel : BaseModel
    {
        List<TModel> GetAll();

        TModel Get(int id);

        TModel Create(TModel model);
    }
}
