using System;
using System.Collections.Generic;
using DynamicProject.ViewModel.Helper;

namespace DynamicProject.BusinesManagerContracts
{
    ///Create Base business manager
    public interface IBaseBusinessManager<TViewModel,TModel> where TViewModel:class ,new() where TModel:class,new()
    {        
        ///Get all items in the table
        TableListViewModel<TViewModel> GetAll();

        ///Get all items with some search condition
        TableListViewModel<TViewModel> GetAll(SearchParameterViewModel searchParameters);

        ///Get object by Id
        TViewModel Get(int id);

        ///Update existing object and return the status
        int Update(TViewModel UpdateObject);

        ///Delete existing objects by ids(Multiple deletion)
        bool Delete(List<int> ids);
    }
}
