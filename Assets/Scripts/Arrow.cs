using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Destruction());
        if (collision.gameObject.tag =="Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
    IEnumerator Destruction()
    {
        yield return new WaitForSeconds(1f);

        Destroy(this.gameObject);
        
    }
}
