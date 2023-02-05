using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentPush : MonoBehaviour
{
    //this is the script for pushing opponents off the platform.

    [SerializeField] private float forceMagnitude;
    
   
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if (rigidbody != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rigidbody.AddForceAtPosition(forceDirection * forceMagnitude *100, transform.position, ForceMode.Impulse);
        }

        


    }

}
