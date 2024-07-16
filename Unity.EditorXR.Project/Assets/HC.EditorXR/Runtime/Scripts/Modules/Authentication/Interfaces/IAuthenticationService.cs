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

using HC.EditorXR.Modules.Authentication.Enums;

namespace HC.EditorXR.Modules.Authentication.Interfaces
{
    public interface IAuthenticationService
    {
        bool IsUserLoggedIn { get; protected set; }
        UserRolesEnum CurrentUserRole { get;}

        bool LogInUser(string user, string pass);
        bool LogOutUser();
        bool RefreshUserToken();
    }
}