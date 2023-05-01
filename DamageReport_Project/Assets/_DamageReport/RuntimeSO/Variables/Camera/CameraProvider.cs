using UnityEngine;

public class CameraProvider : MonoBehaviour
{
    [SerializeField] Camera providedCamera;
    [SerializeField] Variable<Camera> cameraVariable;

    private void Awake()
    {
        cameraVariable.Value = providedCamera;
    }
}
