using System;

namespace DynamicProject.ViewModel
{
    /// summary:
    /// This class is the base class for all view models
    public class BaseViewModel
    {
        ///Key property
        public int Id {get;set;}

        ///resource created by
        public string CreatedBy {get;set;}

        ///Resource creation time
        public DateTime CreatedAt {get;set;}

        ///Resource last modified by
        public string LastModifiedBy {get;set;}
        ///Resource last modified at 
        public DateTime? LastModifiedAt {get;set;}
    }
}