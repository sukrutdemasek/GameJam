using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject drop;
    public GameObject player;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Player")
        {
            anim.Play("OpenChest");
            var dropPosition = new Vector3(1, 1, 0);
            Instantiate(drop);
            drop.transform.position = player.transform.position + dropPosition;
            Destroy(this.gameObject);
            Debug.Log("Chest Opened!");
        }
    }
}
