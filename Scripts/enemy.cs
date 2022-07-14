using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, Range(1f, 20f)] float m_Speed;
    [SerializeField, Range(0f, 5f)] float range;
    [SerializeField] GameObject explode;
    [SerializeField] GameObject bullet;
    private GameObject player;
    public int hp = 100;
    private AudioSource shot;

    public IEnumerator Spawner()
    {
        while (true)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            shot.Play();
            yield return new WaitForSeconds(Random.Range(0f, range + 1f));
        }
    }

    void Start()
    {
        shot = GetComponent<AudioSource>();
        player = GameObject.Find("1").gameObject;
        StartCoroutine(Spawner());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            hp -= 50;
            if (hp == 0)
            {
                if (player.GetComponent<player>().GetHP() > 0) player.GetComponent<player>().AddHP();
                Instantiate(explode, transform.position, transform.rotation);

                Destroy(this.gameObject);
            }// Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * m_Speed * Time.deltaTime);

        if (transform.position.y < -6) Destroy(this.gameObject);
    }
}
