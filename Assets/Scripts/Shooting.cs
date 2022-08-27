using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform FirePoint;
    public float BulletSpeed;
    Vector2 lookDirection;
    float lookAngle;
    public Camera camera;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = camera.WorldToScreenPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject Arrowclone = Instantiate(bullet);
            /*Arrowclone.transform.position = FirePoint.position;
             Arrowclone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
             //Arrows--;*/
            Arrowclone.transform.Translate(mousePosition, Space.World);
            //Arrowclone.GetComponent<Rigidbody2D>().velocity = FirePoint.right * BulletSpeed;


        }

    }
}
