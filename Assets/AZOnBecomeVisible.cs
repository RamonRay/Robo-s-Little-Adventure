using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AZOnBecomeVisible : MonoBehaviour
{
    public bool triggered = false;
    public UnityEvent OnTriggeredEvents;
    private Collider obj;
    public Camera targetCamera;
    Plane[] planes;
    /*  private void OnBecameVisible()
      {
          if (!triggered)
          {

              triggered = true;
              OnTriggeredEvents.Invoke();
          }

      }*/

    private void Start()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(targetCamera);
        obj = GetComponent<Collider>();
    }

    public void Update()
    {

        if (!triggered)
        {
            planes = GeometryUtility.CalculateFrustumPlanes(targetCamera);
            if (GeometryUtility.TestPlanesAABB(planes,obj.bounds))
            {
                triggered = true;
                OnTriggeredEvents.Invoke();

            }


        }

    }
}
