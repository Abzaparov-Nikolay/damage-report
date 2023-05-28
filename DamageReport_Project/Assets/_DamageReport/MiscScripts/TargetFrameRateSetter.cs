using UnityEngine;

public class TargetFrameRateSetter : MonoBehaviour
{
    [SerializeField] private int fps;

    private void Awake()
    {
        Application.targetFrameRate = fps;   
    }
}
