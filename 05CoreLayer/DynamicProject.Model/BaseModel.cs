using System;
using System.ComponentModel.DataAnnotations;
namespace DynamicProject.Model
{
    public class BaseModel
    {
        [Key]
        public virtual int Id {get;set;}

        public string CreatedBy {get;set;}

        public DateTime CreatedAt {get;set;}

        public string ModifiedBy {get;set;}

        [Timestamp,ConcurrencyCheck]        
        public DateTime? ModifiedAt {get;set;}

        
    }
}
