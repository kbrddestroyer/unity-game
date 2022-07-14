using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class explode : MonoBehaviour
{
    // Start is called before the first frame update
    
    public IEnumerator lifetime()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
    
    void Start()
    {
        StartCoroutine(lifetime());
    }

}
