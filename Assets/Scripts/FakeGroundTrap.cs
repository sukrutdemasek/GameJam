using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FakeGroundTrap : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Delay());
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        StopCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(2f);

        this.gameObject.active = false;

       





    }
   
}
