using System;

namespace DynamicProject.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        public string Name {get;set;}

        public string Address {get;set;}

        public int ZipCode  {get;set;}

        public int? PhoneNumber {get;set;}
    }
}
