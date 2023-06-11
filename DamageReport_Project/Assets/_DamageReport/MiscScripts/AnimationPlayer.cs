using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(Animation))]
public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] new private Animation animation;
    public void Play()
    {
        animation.Rewind();
        animation.Play();
    }

    public void Play(string name)
    {
        animation.Rewind(name);
        animation.Play(name);
    }

    public void SetSpeed(float speed)
    {
        foreach (AnimationState clip in animation)
        {
            clip.speed = speed;
        }
    }
}
