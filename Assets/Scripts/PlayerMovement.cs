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
using Debug = System.Diagnostics.Debug;

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
    public Camera camera;
    [SerializeField]
    Animator anim;
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
        if (horizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
        else if (horizontal < 0) gameObject.transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
        if (Health == 0)
        {
            this.gameObject.GetComponent<CheckpointController>().RespawnPlayer();
            //Destroy(this.gameObject);
        }

        horizontal = Input.GetAxisRaw("Horizontal"); //¬Œ“ ƒ¬»∆≈Õ»≈
        if(Mathf.Abs(horizontal) > 0.1f) {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
       
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

       /* lookDirection = camera.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        FirePoint.rotation = Quaternion.Euler(transform.position.x, transform.position.y, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject Arrowclone = Instantiate(Arrow);
            Arrowclone.transform.position = FirePoint.position;
            Arrowclone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            //Arrows--;
            Arrowclone.GetComponent<Rigidbody2D>().velocity = FirePoint.right * ArrowSpeed;
        }*/
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
        if (collision.tag == ("Door"))
        {
            print("Door Opened!");
            SceneManager.LoadScene("Test");
            
        }
    }
}
