using System;

namespace DynamicProject.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        //TODO:Remove once properly implemented
        public UserViewModel()
        {
            this.Name = "User";
        }

        public string Name {get;set;}

        public string Address {get;set;}
    }
}
