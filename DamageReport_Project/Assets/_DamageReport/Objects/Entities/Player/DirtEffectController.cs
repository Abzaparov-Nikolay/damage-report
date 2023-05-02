using UnityEngine;

public class DirtEffectController : MonoBehaviour
{
    [SerializeField] private Variable<Vector2> inputDirection;
    [SerializeField] private ParticleSystem effect;

    private void Update()
    {
        if (inputDirection != Vector2.zero && !effect.isPlaying)
        {
            effect.Play();
        }
        else if (inputDirection == Vector2.zero && effect.isPlaying)
        {
            effect.Stop();
        }
    }
}
