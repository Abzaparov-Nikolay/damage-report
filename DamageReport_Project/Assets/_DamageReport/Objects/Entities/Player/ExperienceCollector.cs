using UnityEngine;

public class ExperienceCollector : MonoBehaviour
{
    [SerializeField] private Reference<float> playerExperience;
    [SerializeField] private Variable<float> experienceMultiplier;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ExperienceParticle>(out var experienceParticle)
            && experienceParticle.IsAttracting)
        {
            playerExperience.Value += experienceParticle.Value * experienceMultiplier;
            Destroy(experienceParticle.gameObject);
        }
    }
}
