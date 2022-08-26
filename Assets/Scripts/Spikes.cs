using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public GameObject[] spikes = new GameObject[0];
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Trigger Worked");
            foreach (var spike in spikes)
            {
                /*spike.GetComponent<Rigidbody2D>().gravityScale = 3f;*/
                StartCoroutine(SpikesActivation());
            }

        }
        IEnumerator SpikesActivation()
        {
            yield return new WaitForSeconds(1f);
            foreach (var spike in spikes)
            {
                spike.GetComponent<Rigidbody2D>().gravityScale = 3f;
            }
            }
            /* foreach (var spike in spikes)
             {
                 if (collision.tag == "Ground")
                 {
                     Destroy(spike);
                 }
             }*/

        }
}
