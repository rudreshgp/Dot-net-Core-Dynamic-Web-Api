namespace DynamicProject.Model
{
    public class User : BaseModel
    {
        public string Name {get;set;}

        public string Address {get;set;}

        public int ZipCode  {get;set;}

        public int? PhoneNumber {get;set;}
        
    }
}