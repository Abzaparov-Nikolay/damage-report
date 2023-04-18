using UnityEngine;

public class ExperienceCollector : MonoBehaviour
{
    [SerializeField] private Reference<float> playerExperience;
    [SerializeField] private Collider collectCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ExperienceParticle>(out var experienceParticle))
        {
            playerExperience.Value += experienceParticle.Value;
            Destroy(experienceParticle.gameObject);
        }
    }
}
