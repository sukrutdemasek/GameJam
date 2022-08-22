using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGroundTrap : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionStay2D(Collision2D collision)
    {
        StartCoroutine(Delay());
        
        
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);

            Destroy(this.gameObject);
        
        
        
    }
}
