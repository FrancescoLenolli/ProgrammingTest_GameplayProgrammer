using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFramework.StateMachine;
using UIFramework.Components;

public class UIView_Main_Options : UIView
{
    public Action<float> onChangeMovementSpeed;
    public Action<float> onChangeRotationSpeed;
    public Action<float> onChangeRotationAngle;
    public Action<float> onChangeScalePercentage;
    public Action onCloseOptions;
    [SerializeField] private CustomSlider sliderMovementSpeed = null;
    [SerializeField] private CustomSlider sliderRotationSpeed = null;
    [SerializeField] private CustomSlider sliderRotationAngle = null;
    [SerializeField] private CustomSlider sliderScalePercentage = null;

    public void Init()
    {
        sliderMovementSpeed.UpdateLabel();
        sliderRotationSpeed.UpdateLabel();
        sliderRotationAngle.UpdateLabel();
        sliderScalePercentage.UpdateLabel();
    }

    public void ChangeMovementSpeed(float value)
    {
        onChangeMovementSpeed?.Invoke(value);
        sliderMovementSpeed.SetValue(value);
    }

    public void ChangeRotationSpeed(float value)
    {
        onChangeRotationSpeed?.Invoke(value);
        sliderRotationSpeed.SetValue(value);
    }

    public void ChangeRotationAngle(float value)
    {
        onChangeRotationAngle?.Invoke(value);
        sliderRotationAngle.SetValue(value);
    }

    public void ChangeScalePercentage(float value)
    {
        onChangeScalePercentage?.Invoke(value);
        sliderScalePercentage.SetValue(value);
    }

    public void CloseOptions()
    {
        onCloseOptions?.Invoke();
    }
}
