using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = MenuNames.Manager + "Experience")]
public class ExperienceManager : ScriptableObject
{
    [SerializeField] private Variable<float> currentExperience;
    [SerializeField] private Variable<float> maxExperience;
    [SerializeField] private Reference<float> nextLevelMultiplier;
    [SerializeField] private UnityEvent onLevelUp;

    public void LevelUp()
    {
        currentExperience.Value = maxExperience;
    }

    private void OnEnable()
    {
        currentExperience.OnChanged += OnExperienceChanged;
    }

    private void OnDisable()
    {
        currentExperience.OnChanged -= OnExperienceChanged;
    }

    private void OnExperienceChanged()
    {
        if (currentExperience < maxExperience)
            return;

        currentExperience.Value = 0;
        maxExperience.Value *= nextLevelMultiplier;
        onLevelUp?.Invoke();
    }
}
