using UnityEngine;

public class ExperienceAttractor : MonoBehaviour
{
    [SerializeField] private Collider attractCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ExperienceParticle>(out var experienceParticle)
            && !experienceParticle.IsAttracting)
        {
            experienceParticle.StartAttracting(transform);
        }
    }
} 
