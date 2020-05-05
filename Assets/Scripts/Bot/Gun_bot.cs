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
        if (player == null)
            return;
        bot = GameObject.FindGameObjectWithTag("Enemy").transform;
        float x = player.position.x - bot.position.x;

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, player.position - bot.transform.position);
        transform.rotation = rotation;

        if (timeBtwShots <= 0)
        {
            Faer();
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

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

    void Faer()
    {
        if (timeBtwShots <= 0)
        {
            
            Instantiate(bullet, shotPoint.position, transform.rotation);
            
        }
        
    }
}
