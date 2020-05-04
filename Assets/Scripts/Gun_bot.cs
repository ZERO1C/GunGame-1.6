using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_bot : MonoBehaviour
{
    public float offset;

    private Transform player;
    private Transform bot;


    private bool facingRight = true;
    
    public GameObject bullet;
    public Transform shotPoint;


    
    private float timeBtwShots;
    public float startTimeBtwShots;



    void Start()
    {

    }


    void Update()
    {





        player = GameObject.FindGameObjectWithTag("Player").transform;
        bot = GameObject.FindGameObjectWithTag("Enemy").transform;
        int x = Mathf.RoundToInt(player.position.x) - Mathf.RoundToInt(bot.position.x);

        //int playerx = Mathf.RoundToInt(player.position.x);
        //int playery = Mathf.RoundToInt(player.position.y);


        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, player.position - bot.transform.position);
        transform.rotation = rotation;

        if (facingRight == true && x < 0)
        {
            Flip();
        }
        else if (facingRight == false && x < 0)
        {
            Flip();
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.y *= -1;
        transform.localScale = Scaler;
    }
}
