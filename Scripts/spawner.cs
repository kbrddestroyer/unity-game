using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class spawner : MonoBehaviour
{
    [SerializeField] public GameObject enemy;
    public static float spawnRate = 1f;

    private AudioSource shot;
    public IEnumerator Spawner()
    {
        yield return new WaitForSeconds(5f);
        while (true)
        {
            float x = Random.Range(-9, 9);
            Instantiate(enemy, new Vector3(x, 6, 0), transform.rotation);
            Instantiate(enemy, new Vector3(x * (-1), 6, 0), transform.rotation);

            yield return new WaitForSeconds(spawnRate);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
