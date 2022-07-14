using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_background : MonoBehaviour
{
    bool created_copy = false;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * (1f) * Time.deltaTime);
        if (transform.position.y < 0 && !created_copy)
        {
            created_copy = true;
            Vector3 pos = transform.position;
            pos.y += 10.2f;
            Instantiate(this.gameObject, pos, transform.rotation);
        }
        if (transform.position.y < -10) Destroy(this.gameObject);
    }
}
