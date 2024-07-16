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
/// Creation Date: 07/15/2024
/// Update Date: 07/15/2024
/// Description: 
///     
/// --------------------

using HC.EditorXR.Data_Classes.Authentication.Attributes;
using HC.EditorXR.Injector;
using HC.EditorXR.Modules.Authentication.Enums;
using HC.EditorXR.Modules.Authentication.Interfaces;
using HC.Unity.EditorXR.MainMenu;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using Zenject;

namespace HC.EditorXR.Modules.Authentication.Menu
{
    [AuthenticationAccess(UserRolesEnum.NotAuthenticated)]
    public class LogInScreen : ZenAutoInjecter
    {
        private static LogInScreen _instance;
        
        [SerializeField] private Button _closeButton;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _alphaFadeTime = 0.5f;
        [SerializeField] private TMP_InputField _usernameInputField;
        [SerializeField] private TMP_InputField _passwordInputField;
        [SerializeField] private Toggle _rememberMeToggle;
        [SerializeField] private Button _loginButton;
        
        [Inject] private IAuthenticationService _authenticationService;

        private new void Awake()
        {
            if (_instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            _instance = this;
            
            base.Awake();
            
            Assert.IsNotNull(_closeButton);
            Assert.IsNotNull(_usernameInputField);
            Assert.IsNotNull(_passwordInputField);
            Assert.IsNotNull(_rememberMeToggle);
            Assert.IsNotNull(_loginButton);
            
            _canvasGroup.alpha = 0f;
            LeanTween.alphaCanvas(_canvasGroup, 1, _alphaFadeTime);
            
            _closeButton.onClick.AddListener(()=>
            {
                LeanTween.alphaCanvas(_canvasGroup, 0, _alphaFadeTime).setOnComplete(() => Destroy(this.gameObject));
                _instance = null;
            });
            
            _loginButton.onClick.AddListener(() =>
            {
                // TODO > Check for empty Fields
                _authenticationService.LogInUser(_usernameInputField.text, _passwordInputField.text);
                _instance = null;
                Destroy(this.gameObject);
            });
        }
    }
}