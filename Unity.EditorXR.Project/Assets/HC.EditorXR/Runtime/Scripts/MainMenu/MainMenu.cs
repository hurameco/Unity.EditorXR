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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HC.EditorXR.Data_Classes.Authentication.Attributes;
using HC.EditorXR.Injector;
using HC.EditorXR.Modules.Authentication.Interfaces;
using HC.Unity.EditorXR.MainMenu.ScriptableObjects;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using Zenject;

namespace HC.Unity.EditorXR.MainMenu
{
    public class MainMenu : ZenAutoInjecter
    {
        private const string k_PrefabsMenusLocation = "Prefabs/UI/Menus";

        [SerializeField] private GameObject _mainMenuButtonPrefab;
        [SerializeField] private Transform _mainMenuButtonPlaceholder;

        [Header("Configuration")] [SerializeField]
        private CanvasGroup _canvasGroup;

        [SerializeField] private float _alphaFadeTime = 0.5f;
        [SerializeField] private float _scaleAnimationTime = 0.5f;
        [SerializeField] private Vector3 _initialSize;

        [Inject] private IAuthenticationService _authenticationProvider;
        [Inject] private MainMenuOptionsScriptableObject _mainMenuOptions;

        protected void OnEnable()
        {
            Assert.IsNotNull(_mainMenuButtonPrefab);
            Assert.IsNotNull(_mainMenuButtonPlaceholder);
            Assert.IsNotNull(_canvasGroup);

            //this.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);_canvasGroup.alpha = 0f;
            _canvasGroup.alpha = 0;
            LeanTween.alphaCanvas(_canvasGroup, 1, _alphaFadeTime).setEase(LeanTweenType.easeSpring);
            LeanTween.scale(this.gameObject, _initialSize, _scaleAnimationTime);

            foreach (var option in _mainMenuOptions.Options)
            {
                if ((option.UserRole & _authenticationProvider.CurrentUserRole) != 0)
                {
                    Instantiate(_mainMenuButtonPrefab, _mainMenuButtonPlaceholder).GetComponentInChildren<MainMenuButton>().SetupButton(option);
                }
            }
        }
    }
}