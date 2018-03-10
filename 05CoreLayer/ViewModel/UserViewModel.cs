using System;

namespace ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        //TODO:Remove once properly implemented
        public UserViewModel()
        {
            this.Name = "User";
        }

        public int Id {get;set;}

        public string Name {get;set;}

        public string Address {get;set;}
    }
}
