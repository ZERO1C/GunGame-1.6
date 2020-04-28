using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pol : MonoBehaviour
{



    
    public float lifitime;
    public float distance;
    public LayerMask whatIsSolid;

    private void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, -transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            
            Destroy(gameObject);


        }
        
    }
}
