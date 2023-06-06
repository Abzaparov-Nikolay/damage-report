using UnityEngine;

public class ExperienceAttractor : MonoBehaviour
{
    [SerializeField] private SphereCollider attractCollider;
    [SerializeField] private Stat attractRadius; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ExperienceParticle>(out var experienceParticle)
            && !experienceParticle.IsAttracting)
        {
            experienceParticle.StartAttracting(transform);
        }
    }

	private void Start()
	{
		SetColliderRadius();
	}

	private void OnEnable()
	{
        attractRadius.OnChanged += SetColliderRadius;

	}
	private void OnDisable()
	{
		attractRadius.OnChanged -= SetColliderRadius;
	}

	private void SetColliderRadius()
	{
		attractCollider.radius = attractRadius.Get();
	}
} 
