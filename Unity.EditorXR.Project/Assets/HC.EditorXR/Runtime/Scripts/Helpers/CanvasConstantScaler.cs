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

using UnityEngine;

namespace HC.EditorXR.UI
{
    public class CanvasConstantScaler : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _rect;

        private float _initialRectWidth;
        private float _initialRectHeight;
        private float _initialParentLossyScaleX;
        private float _initialParentLossyScaleY;
        private float _initialLocalScaleX; 
        private float _initialLocalScaleY;

        private void Start()
        {
            _initialRectWidth = _rect.rect.size.x;
            _initialRectHeight = _rect.rect.size.y;
            _initialLocalScaleX = transform.localScale.x;
            _initialLocalScaleY = transform.localScale.y;
            _initialParentLossyScaleX = transform.parent.lossyScale.x;
            _initialParentLossyScaleY = transform.parent.lossyScale.y;

        }

        private void Update()
        {

            float factorX = transform.parent.lossyScale.x / _initialParentLossyScaleX;
            float factorY = transform.parent.lossyScale.y / _initialParentLossyScaleY;
            transform.localScale = new Vector3(
                _initialLocalScaleX / factorX,
                _initialLocalScaleY / factorY,
                transform.localScale.z);
            _rect.sizeDelta = new Vector2(_initialRectWidth * factorX, _initialRectHeight * factorY);
        }
    }
}