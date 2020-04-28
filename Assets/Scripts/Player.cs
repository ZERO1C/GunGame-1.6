using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Hitpoint;


    private void Update()
    {
        if (Hitpoint <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void TakeDamage(int damage)
    {
        Hitpoint -= damage;


    }
}
