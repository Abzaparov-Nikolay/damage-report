using UnityEngine;

public class ExperienceSpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody experienceParticlePrefab;
    [SerializeField] private int spawnCount;
    [SerializeField] private Reference<float> momentum;
    [SerializeField] private Reference<float> minVerticalAngle;

    public void Spawn()
    {
        for (var i = 0; i < spawnCount; i++)
        {
            var newExperienceParticleBody = Instantiate(experienceParticlePrefab, transform.position, Quaternion.identity);
            var spawnDirection = Quaternion.Euler(0, Random.Range(0, 360), Random.Range(minVerticalAngle, 90));
            var spawnForce = spawnDirection * Vector3.right * momentum;
            newExperienceParticleBody.AddForce(spawnForce, ForceMode.Impulse);
        }
    }
}
