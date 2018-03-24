using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicProject.ViewModel.Helper;

namespace DynamicProject.BusinesManagerContracts
{
    ///Create Base business manager
    public interface IBusinessManager<TViewModel,TModel> where TViewModel:class ,new() where TModel:class,new()
    {        
        ///Get all items in the table
        Task<List<TViewModel>> GetAll();

        ///Get all items with some search condition
        List<TViewModel> GetAll(SearchParameterViewModel searchParameters);


        ///create new object and return the same
        TViewModel Create(TViewModel newObject);

        ///Get object by Id
        TViewModel Get(int id);

        ///Update existing object and return the status
        int Update(TViewModel UpdateObject);

        ///Delete existing objects by ids(Multiple deletion)
        bool Delete(List<int> ids);
    }
}
