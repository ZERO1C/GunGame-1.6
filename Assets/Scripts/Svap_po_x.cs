using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Svap_po_x : MonoBehaviour
{
    private bool facingRight = true;




    void Start()
    {
        
    }

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float x = difference.x;
        if (facingRight == true && x < 0)
        {
            Flip();
        }
        else if (facingRight == false && x > 0)
        {
            Flip();
        }
    }




    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
