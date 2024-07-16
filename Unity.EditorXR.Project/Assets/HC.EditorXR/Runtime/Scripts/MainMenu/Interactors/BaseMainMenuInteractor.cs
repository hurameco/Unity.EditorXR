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
/// Creation Date: 02/07/2024
/// Update Date: 02/07/2024
/// Description: 
///     Base script that is responsible for detecting when the main menu should appear
/// --------------------

using System;
using System.Collections.Generic;
using System.Linq;
using HC.EditorXR.Modules.Authentication.Interfaces;
using UnityEngine;
using Zenject;

namespace HC.Unity.EditorXR.MainMenu.Interactors
{
    public abstract class BaseMainMenuInteractor : MonoBehaviour
    {
        
        protected static GameObject _mainMenuInstance;
        protected static BaseMainMenuInteractor _activeMainMenuInteractor; 
        
        [Header("MainMenu Prefab")]
        [SerializeField] protected GameObject _mainMenuPrefab;


    }
}