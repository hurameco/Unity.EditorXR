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

using HC.EditorXR.Modules.Authentication;
using HC.EditorXR.Modules.Authentication.Interfaces;
using HC.Unity.EditorXR.MainMenu.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace HC.EditorXR.Injector
{
    
    public class CustomBindingsInstaller : MonoInstaller
    {
        [SerializeField] private string _menuOptionsScriptableObjectPath;
        public override void InstallBindings()
        {
            // All necessary bindings for Dependency Injection using Zenject
            Container.Bind<IAuthenticationService>().To<AuthenticationServiceDummy>().AsSingle();
            Container.Bind<MainMenuOptionsScriptableObject>().FromScriptableObjectResource(_menuOptionsScriptableObjectPath).AsSingle();
        }
    }
}