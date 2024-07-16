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
    public class LogOutScreen : ZenAutoInjecter
    {
        private static LogOutScreen _instance;


        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _alphaFadeTime = 0.5f;
        [SerializeField] private TextMeshProUGUI _informationText;
        [SerializeField] private Button _logOutButton;
        [SerializeField] private Button _CancelButton;

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

            Assert.IsNotNull(_canvasGroup);
            Assert.IsNotNull(_informationText);
            Assert.IsNotNull(_logOutButton);
            Assert.IsNotNull(_CancelButton);

            _canvasGroup.alpha = 0f;
                LeanTween.alphaCanvas(_canvasGroup, 1, _alphaFadeTime);
            

            _CancelButton.onClick.AddListener(() =>
            {
                _instance = null;
                LeanTween.alphaCanvas(_canvasGroup, 0, _alphaFadeTime).setOnComplete(() => Destroy(this.gameObject));
            });
            
            _logOutButton.onClick.AddListener(() =>
            {
                _authenticationService.LogOutUser();
                _instance = null;
                Destroy(this.gameObject);
            });
        }
    }
}