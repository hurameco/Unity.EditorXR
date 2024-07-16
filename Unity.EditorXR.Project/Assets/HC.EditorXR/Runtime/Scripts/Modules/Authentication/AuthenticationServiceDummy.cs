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
using HC.EditorXR.Modules.Authentication.Interfaces;

namespace HC.EditorXR.Modules.Authentication
{
    public class AuthenticationServiceDummy: IAuthenticationService
    {
        private bool _isUserLoggedIn;
        private UserRolesEnum _currentUserRole = UserRolesEnum.NotAuthenticated;

        bool IAuthenticationService.IsUserLoggedIn
        {
            get => _isUserLoggedIn;
            set => _isUserLoggedIn = value;
        }

        UserRolesEnum IAuthenticationService.CurrentUserRole
        {
            get => _currentUserRole;
        }

        public bool LogInUser(string user, string pass)
        {
            _isUserLoggedIn = true;
            _currentUserRole = UserRolesEnum.Admin;
            return true;
        }

        public bool LogOutUser()
        {
            _isUserLoggedIn = false;
            _currentUserRole = UserRolesEnum.NotAuthenticated;
            return true;
        }

        public bool RefreshUserToken()
        {
            _isUserLoggedIn = true;
            return true;
        }
    }
}