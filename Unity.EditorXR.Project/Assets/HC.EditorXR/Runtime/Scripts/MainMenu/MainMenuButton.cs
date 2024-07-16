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
using HC.Unity.EditorXR.MainMenu.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace HC.Unity.EditorXR.MainMenu
{
    public class MainMenuButton : MonoBehaviour
    {
        [SerializeField] private Image _imageComponent;
        [SerializeField] private Button _buttonComponent;
        [SerializeField] private TextMeshProUGUI _titleTextComponent;
        [SerializeField] private TextMeshProUGUI _descriptionTextComponent;

        [Header("Configuration")] [SerializeField]
        private float _minWidthToShowText = 256;

        //private MainMenuOptionsScriptableObject.MenuOptions _buttonOption;
        private RectTransform _canvasRect;

        private void Awake()
        {
            Assert.IsNotNull(_imageComponent);
            Assert.IsNotNull(_buttonComponent);
            Assert.IsNotNull(_titleTextComponent);
            Assert.IsNotNull(_descriptionTextComponent);
        }

        public void SetupButton(MainMenuOptionsScriptableObject.MenuOptions buttonOption)
        {
            Debug.Log(buttonOption.ButtonTitle);
            _imageComponent.sprite = buttonOption.ButtonSprite;
            if (buttonOption.MenuPrefab != null)
                _buttonComponent.onClick.AddListener(() => { Instantiate(buttonOption.MenuPrefab); });
            _buttonComponent.onClick.AddListener(buttonOption.OnClickEvent.Invoke);
            _titleTextComponent.text = buttonOption.ButtonTitle;
            _descriptionTextComponent.text = buttonOption.ButtonDescription;
        }

        private void Update()
        {
            if (_canvasRect == null)
                _canvasRect = this.GetComponentInParent<Canvas>().gameObject.transform as RectTransform;

            _titleTextComponent.gameObject.SetActive(_canvasRect.sizeDelta.x > _minWidthToShowText);
            _descriptionTextComponent.gameObject.SetActive(_canvasRect.sizeDelta.x > _minWidthToShowText);
        }
    }
}