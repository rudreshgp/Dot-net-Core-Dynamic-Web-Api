using System;

namespace ViewModel
{
    public class RoleViewModel : BaseViewModel
    {
        //TODO:Remove once properly implemented
        public RoleViewModel()
        {
            this.Name = "Role";
        }
        public int Id {get;set;}

        public string Name {get;set;}

    }
}
