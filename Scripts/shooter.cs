using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class shooter : MonoBehaviour
{
    [SerializeField] public bool isPlayerAttachment; 
    [SerializeField] GameObject bullet;
    
    [SerializeField, Range(0.01f, 1f)] public float shotTime;
    private static bool firing = false;
    public static ObjectPool<GameObject> bullets;
    private AudioSource shotSound;

    // Start is called before the first frame update
    void Start()
    {
        if (!isPlayerAttachment)
        {
            firing = true;
            StartCoroutine(Fire());
        }

        shotSound = GetComponent<AudioSource>();    
        bullets = new ObjectPool<GameObject>(
            () => { return Instantiate(bullet, transform.position, transform.rotation); },
            g_object => { g_object.SetActive(true); },
            g_object => { g_object.SetActive(false); },
            g_object => { Destroy(g_object); }
            ); 
    }

    public IEnumerator Fire()
    {
        while (firing)
        {
            GameObject b = bullets.Get();
            shotSound.Play();
            yield return new WaitForSeconds(shotTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerAttachment && Input.GetKey(KeyCode.Space) && !firing && GameObject.Find("1").GetComponent<player>().GetHP() > 0)
        {   
            firing = true;
            StartCoroutine(Fire());
        }
        if (Input.GetKeyUp(KeyCode.Space)) firing = false;
    }

}
