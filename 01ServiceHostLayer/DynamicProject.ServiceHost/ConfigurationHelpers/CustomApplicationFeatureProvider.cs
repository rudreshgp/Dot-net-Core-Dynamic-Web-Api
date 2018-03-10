using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;

namespace DynamicProject.ServiceHost.ConfigurationHelpers
{

    /// <summary>
    /// This class is used to tell mvc to find controllers whose name doesn't end with Controller
    /// </summary>
    public class CustomApplicationFeatureProvider : ControllerFeatureProvider
    {
        ///Create list of valid dynamic controller endings
        // private static readonly List<string> _validControllerEndings = new List<string>{"CustomEndingName"};


        ///Override base provider and if false check for dynamic controller name
        // protected override bool IsController(TypeInfo typeInfo)
        // {
            
        //     var isController = base.IsController(typeInfo);
        //     if(!isController)
        //     {
        //         if( _validControllerEndings.Any(x=>typeInfo.Name.EndsWith(x,StringComparison.OrdinalIgnoreCase))){
        //             isController = true;
        //         }
        //     }
        //     return isController;
        // }
    }
}
