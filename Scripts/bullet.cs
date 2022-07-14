using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField, Range(-20f, 20f)] float m_Speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy_plane" && this.tag == "Bullet") Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.y >= 6 && m_Speed > 0) || (transform.position.y <= -6 && m_Speed < 0)) Destroy(this.gameObject);
        transform.Translate(new Vector3(0, 1, 0) * m_Speed * Time.deltaTime);
    }
}
