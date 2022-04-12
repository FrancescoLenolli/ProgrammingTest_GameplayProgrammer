using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

namespace UIFramework.Components
{
    public class CustomSlider : UIComponent
    {
        [SerializeField] private TextMeshProUGUI labelValue = null;
        private Slider slider;

        private void Awake()
        {
            slider = GetComponent<Slider>();
        }

        public void Init(float minValue, float maxValue, float startingValue,
            bool wholeNumbers = false, UnityAction<float> action = null)
        {
            if(!slider)
            slider = GetComponent<Slider>();

            slider.minValue = minValue;
            slider.maxValue = maxValue;
            slider.value = startingValue;
            slider.wholeNumbers = wholeNumbers;
            UpdateLabel();

            if (action != null)
                SetAction(action);
        }

        public void UpdateLabel()
        {
            labelValue.text = string.Format("{0:G}", slider.value);
        }

        public void SetAction(UnityAction<float> action)
        {
            slider.onValueChanged.RemoveAllListeners();
            slider.onValueChanged.AddListener(action);
        }

        public void SetValue(float value)
        {
            slider.value = value;
            UpdateLabel();
        }

        public float GetValue()
        {
            return slider.value;
        }

        public void ResetValue()
        {
            slider.value = slider.maxValue;
            UpdateLabel();
        }

        public void EnableSlider(bool isInteractable)
        {
            slider.interactable = isInteractable;
        }
    }
}