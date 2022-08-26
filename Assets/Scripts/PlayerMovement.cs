using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 10f;
    private bool isFacingRight = true;
    public GameObject Arrow;
    public int ArrowSpeed;
    public Transform FirePoint;
    public int Health = 3;
    public Text health;
    public bool KeyFound = false;
    public Image KeyInInventory;
    public GameObject DoorTrig;
    //public int Arrows = 8;

    Vector2 lookDirection;
    float lookAngle;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundlayer;
    // Start is called before the first frame update


    private void Start()
    {
        KeyInInventory.enabled = false;
        DoorTrig.SetActive(false);
        health.text = health.text + Health;

    }
    // Update is called once per frame
    void Update()
    {
        UnityEngine.Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        /*var PlayerScale = this.gameObject.transform.localScale.x;*/

        if (horizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
        else if (horizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
        }
            if (Health <= 0)
            {
                Destroy(this.gameObject);

            }
        
        
        health.text = health.text + Health;
        horizontal = Input.GetAxisRaw("Horizontal"); //¬Œ“ ƒ¬»∆≈Õ»≈

        Flip();

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            //œ–€∆Œ 
        }
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y > 0f)
        {
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 1f);
                //“Œ∆≈ œ–€∆Œ 
            }
        }
        //Vector2 playerPosition = transform.position;
        lookDirection = Camera.main. ScreenToWorldPoint(Input.mousePosition);
        //print(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
       // Vector2 direction = lookDirection - playerPosition;
      //  transform.right = direction;
        FirePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject Arrowclone = Instantiate(Arrow);
            Arrowclone.transform.position = FirePoint.position;
            Arrowclone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
           /* Arrowclone.GetComponent<Rigidbody2D>().AddForce(lookDirection, new ForceMode2D());
            Arrowclone.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 3f) * ArrowSpeed;*/
            Arrowclone.GetComponent<Rigidbody2D>().velocity = Arrowclone.transform.right.normalized * ArrowSpeed;
        }




    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y);

        
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Bullet") )
        {
            Health--;
            Destroy(collision.gameObject);

        }
        if (collision.tag == ("Heart") && gameObject.tag == ("Player"))
        {
            Health++;
            Destroy(collision.gameObject);
        }
        if (collision.tag == ("Key"))
        {
            print("Key Found!");
            KeyInInventory.enabled = true;
            DoorTrig.SetActive(true);
            Destroy(collision.gameObject);

        }
       /* if (collision.tag == ("Door"))
        {
            print("Door Opened!");
            SceneManager.LoadScene("Test");


        }*/
    }
}
