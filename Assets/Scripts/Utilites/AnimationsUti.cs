using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Utilities
{
    public class AnimationsUti : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private Slider _slider;
        private Transform _standardTransform;
        
        
        private readonly Vector3 _targetScale = new Vector3(1.1f, 1.1f, 1.1f);
        private readonly float _scaleDuration = 0.15f;


        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _standardTransform = transform;
        }

        /*void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_rectTransform != null)
                {
                    PlayUIScaleInAnimation();
                }
                else
                {
                    PlayScaleInAnimation();
                }
            }
 
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (_rectTransform != null)
                {
                    OnMouseEnterUIAnimation();
                }
                else
                {
                    OnMouseEnterAnimation();
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (_rectTransform != null)
                {
                    OnMouseExitUIAnimation();
                }
                else
                {
                    OnMouseExitAnimation();
                }
            }
        }*/

        private void PlayScaleInAnimation() // FOR OBJECT PRESS
        {
            transform.DOScale(_targetScale, _scaleDuration).OnComplete(() =>
            {
                transform.DOScale(new Vector3(0.90f, 0.90f, 0.90f),0.15f).OnComplete(() =>
                {
                    transform.DOScale(Vector3.one, 0.15f);
                });

            });
        }

        private void OnMouseEnterAnimation() // FOR OBJECT MOUSE ENTER
        {
            transform.DOScale(_targetScale, _scaleDuration);
        }
        
        private void OnMouseExitAnimation() // FOR OBJECT MOUSE EXIT
        {
            transform.DOScale(new Vector3(0.90f, 0.90f, 0.90f),0.15f).OnComplete(() =>
            {
                transform.DOScale(Vector3.one, 0.15f);
            });        
        }

        private void PlayUIScaleInAnimation() // FOR UI PRESS
        {
            _rectTransform.DOScale(_targetScale, _scaleDuration).OnComplete(()=>
            {
                _rectTransform.DOScale(new Vector3(.90f,0.90f,0.90f),0.15f).OnComplete(()=>
                {
                    _rectTransform.DOScale(Vector3.one, 0.15f);
                });
            });
        }
        
        private void OnMouseEnterUIAnimation() // FOR UI MOUSE HOVER
        {
            _rectTransform.DOScale(_targetScale, _scaleDuration);
        }

        
        private void OnMouseExitUIAnimation() // FOR UI MOUSE EXIT
        {
            _rectTransform.DOScale(new Vector3(0.90f, 0.90f, 0.90f),0.15f).OnComplete(() =>
            {
                _rectTransform.DOScale(Vector3.one, 0.15f);
            });        
        }

        public void AnimateSliderHandle() // FOR SLIDER
        {
            if (_slider != null)
            {
                float targetValue = _slider.value;
                // Animate the handle to the current value of the slider
                _slider.DOValue(targetValue, _scaleDuration);
            }
        }

    }
}