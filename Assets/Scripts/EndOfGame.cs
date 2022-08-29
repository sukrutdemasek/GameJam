using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfGame : MonoBehaviour
{

    public GameObject GameOver;

    private void Awake()
    {
        GameOver.SetActive(false);
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameOver.SetActive(true);
        }
    }
}
