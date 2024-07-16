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
using HC.EditorXR.Modules.Authentication.Enums;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace HC.Unity.EditorXR.MainMenu.ScriptableObjects
{
    [CreateAssetMenu(fileName = "DefaultMenuOptions", menuName = "HC.Editor/ScriptableObjects/MenuOptions", order = 1)]
    public class MainMenuOptionsScriptableObject : ScriptableObject
    {
        [SerializeField] private List<MenuOptions> _options = new List<MenuOptions>();

        public List<MenuOptions> Options => _options;
        
        [Serializable]
        public class MenuOptions
        {
            [FormerlySerializedAs("buttonTItle")] [FormerlySerializedAs("_buttonName")] [SerializeField] private string buttonTitle; 
            [SerializeField] private Sprite _buttonSprite;
            [SerializeField] private string _buttonDescription; 
            [SerializeField] private GameObject _menuPrefab;
            [SerializeField] private UserRolesEnum _userRole;
            [SerializeField] private UnityEvent _onClickEvent = new UnityEvent();

            public string ButtonTitle=> buttonTitle;
            public Sprite ButtonSprite => _buttonSprite;
            public string ButtonDescription => _buttonDescription;
            public GameObject MenuPrefab => _menuPrefab;
            public UserRolesEnum UserRole => _userRole;
            public UnityEvent OnClickEvent => _onClickEvent;
        }
    }
}