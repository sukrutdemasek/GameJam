using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public float FireRate = 1f;
    public float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time )
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + FireRate;
        }
        //transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
    }

    /* private void OnTriggerStay2D(Collider2D collision)
     {
         transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
     }*/


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Arrow")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}

