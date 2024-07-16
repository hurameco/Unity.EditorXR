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
///     Hand script that is responsible for detecting when the main menu should appear
/// --------------------

using System;
using System.Collections;
using HC.EditorXR.Injector;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;
using Zenject;

namespace HC.Unity.EditorXR.MainMenu.Interactors
{
    public class HandMainMenuInteractor : BaseMainMenuInteractor
    {
        [Serializable]
        protected enum SidesEnum
        {
            Up,
            Down,
            Left,
            Right,
            Forward,
            Backward
        }
        
        [Header("Offset")]
        [SerializeField] protected Vector3 _openMenuPosOffset = Vector3.zero;
        [SerializeField] protected Vector3 _openMenuRotOffset = Vector3.zero;
        
        [Header("Angles")]
        [SerializeField] protected SidesEnum _ownSideToCheck = SidesEnum.Forward;
        [SerializeField] protected Transform _otherTransform;
        [SerializeField] protected SidesEnum _otherSideToCheck = SidesEnum.Forward;
        [SerializeField] protected float _minAngleToOpenEditorXRMainMenu = 157.5f;
        [SerializeField] protected float _minAngleToCloseEditorXRMainMenu = 120f;
        
        [Header("Invoke Repeating Timer")]
        [SerializeField] protected float _timeToCheck = 0.5f;
        
        private void Awake()
        {
            Assert.IsNotNull(_mainMenuPrefab);
            Assert.IsNotNull(_otherTransform);
        }

        private void OnEnable()
        {
            InvokeRepeating("CheckIfNeedsToOpenMenu", _timeToCheck, _timeToCheck);
        }

        private void CheckIfNeedsToOpenMenu()
        {
            if (_mainMenuInstance != null && _activeMainMenuInteractor != this) return;
            
            Vector3 ownVector;
            Vector3 otherVector;
            
            ownVector = SideToVector3(this.transform);
            otherVector = SideToVector3(_otherTransform);

            var angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(ownVector, otherVector));
            
            if (_mainMenuInstance == null && angle >= _minAngleToOpenEditorXRMainMenu)
            {
                // TODO > Add Main as child of hand
                _mainMenuInstance = Instantiate(_mainMenuPrefab);
                _activeMainMenuInteractor = this;
            }
            else if (_mainMenuInstance != null && angle < _minAngleToCloseEditorXRMainMenu)
            {
                Destroy(_mainMenuInstance);
                _activeMainMenuInteractor = null;
            }
        }

        private Vector3 SideToVector3(Transform t)
        {
           switch (_ownSideToCheck)
            {
                case SidesEnum.Up:
                    return t.up;
                case SidesEnum.Down:
                    return -t.up;
                case SidesEnum.Left:
                     return -t.right;
                case SidesEnum.Right:
                    return t.right;
                case SidesEnum.Backward:
                    return -t.forward;
                default:
                case SidesEnum.Forward:
                    return t.forward;
            }
        }
    }
}