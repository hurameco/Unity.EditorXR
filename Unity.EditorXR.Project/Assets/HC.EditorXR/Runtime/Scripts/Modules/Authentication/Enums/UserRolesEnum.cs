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

namespace HC.EditorXR.Modules.Authentication.Enums
{
    [Flags] [Serializable]
    public enum UserRolesEnum
    {
        NotAuthenticated = 1 << 0,
        Designer = 1 << 1,
        Trainer= 1 << 2,
        Trainee= 1 << 3,
        Admin = Designer | Trainer | Trainee
    }
}