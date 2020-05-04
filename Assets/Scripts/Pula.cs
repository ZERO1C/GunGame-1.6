using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pula : MonoBehaviour
{



    public float speed;
    public float lifitime;
    public float distance;
    public int tolkanX;
    public int tolkanY;
    public LayerMask whatIsSolid;


   
    private void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(tolkanX, tolkanY);

            }
            Destroy(gameObject);
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
