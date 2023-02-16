using UnityEngine;
using UnityEngine.UI;

public class SliderSetter : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private Reference<float> value;
    [SerializeField] private Reference<float> maxValue;

    private void OnEnable()
    {
        value.OnChanged += SetSliderValue;
        maxValue.OnChanged += SetSliderValue;
        SetSliderValue();
    }

    private void OnDisable()
    {
        value.OnChanged -= SetSliderValue;
        maxValue.OnChanged -= SetSliderValue;
    }

    private void SetSliderValue()
    {
        slider.value = value / maxValue;
    }
}
