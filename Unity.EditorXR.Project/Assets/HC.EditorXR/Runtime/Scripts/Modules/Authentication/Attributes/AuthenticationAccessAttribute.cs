/// --------------------
///  /##   /##  /###### 
/// | ##  | ## /##__  ##
/// | ##  | ##| ##  \__/
/// | ########| ##      
/// | ##__  ##| ##      
/// | ##  | ##| ##    ##
/// | ##  | ##|  ######/
/// |__/  |__/ \______/ 
/// 
/// Creation Date: 07/12/2024
/// Update Date: 07/12/2024
/// Description: 
///     
/// --------------------

using System;
using HC.EditorXR.Modules.Authentication.Enums;

namespace HC.EditorXR.Data_Classes.Authentication.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AuthenticationAccessAttribute : Attribute
    {
        internal UserRolesEnum UserRole { get; }

        internal AuthenticationAccessAttribute(UserRolesEnum userRole)
        {
            UserRole = userRole;
        }
    }
}