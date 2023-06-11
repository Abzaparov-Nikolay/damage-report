using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSelector : MonoBehaviour
{
    [SerializeField] new private Camera camera;
    private RaycastHit[] hits = new RaycastHit[1];
    public void OnTouch(Vector2 pos)
    {
        var origin = camera.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 0));
        var ray = new Ray(origin, camera.transform.forward);
        if (Physics.RaycastNonAlloc(ray, hits) > 0)
        {
            //hits[0].collider.gameObject.SetActive(false);
            if (hits[0].collider.gameObject.TryGetComponent<EventResponse>(out var eventResponse))
            {
                eventResponse.Raise(hits[0].collider.gameObject);
            }
        }
    }
}
