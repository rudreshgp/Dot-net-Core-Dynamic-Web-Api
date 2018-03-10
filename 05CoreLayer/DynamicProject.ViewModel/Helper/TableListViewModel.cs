using System;
using System.Collections.Generic;

namespace DynamicProject.ViewModel.Helper
{
    ///Return as row value count
    public class TableListViewModel<T> where T:class,new()
    {
        public int count {get;set;}

        public List<T> rows {get;set;}
    }
}
