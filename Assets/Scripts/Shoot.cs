using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
   
    public GameObject Arrow;
    public float ArrowSpeed;
    public Camera cam;
    // Update is called once per frame
    void Update()
    {
        var lookDirection = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
      
        if (Input.GetMouseButtonDown(0))
        {
            
            GameObject Arrowclone = Instantiate(Arrow, transform.position, Quaternion.identity );
           
        
            //Arrows--;
            Arrowclone.GetComponent<Rigidbody2D>().velocity = transform.right * ArrowSpeed;
            Arrowclone.transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }
}
