using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{
    [SerializeField] Text hp_text;
    [SerializeField] Text sc_text;
    [SerializeField] Image damage_fx;
    [SerializeField] GameObject explode;
    public int hp = 100;
    public const float moveSpeed = 12f;
    
    public Sprite left;
    public Sprite center;
    public Sprite right;

    private bool active = true;
    private bool dead_c = false;
    // Start is called before the first frame update

    public int GetHP() { return hp; }

    public IEnumerator DamageFX()
    {
        if (!active) yield return null;
        Color color = damage_fx.color;
        color.a = 0.5f;
        damage_fx.color = color;
        yield return new WaitForSeconds(0.1f);

        while (color.a > 0f)
        {
            color.a -= 0.1f;
            damage_fx.color = color;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator InactiveSet()
    {
        yield return new WaitForSeconds(1f);
        active = true;
        yield return null;
    }

    IEnumerator Die()
    {
        Debug.Log("Dead!");
        GetComponent<SpriteRenderer>().sprite = null;
        Instantiate(explode, transform.position, transform.rotation);
        dead_c = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        hp = 100;
        dead_c = false;
        yield return null;
    }

    public void AddHP()
    {
        hp += 10;
        if (hp > 100) hp = 100;
        hp_text.text = hp.ToString();
        sc_text.text = (int.Parse(sc_text.text) + 1).ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && active)
        {
            active = false;
            StartCoroutine(InactiveSet());
            StartCoroutine(DamageFX());
            hp -= 25;
            if (hp < 0) hp = 0;
            hp_text.text = hp.ToString();
        }
        if (collision.tag == "Enemy_plane" && hp > 0)
        {
            hp = 0;
        }
    }

    void Update()
    {
        if (hp > 0)
        {
            float moveX = Input.GetAxis("Horizontal");
            transform.Translate(new Vector3(moveX, 0, 0) * moveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, -2.85f, 0);

            if (moveX < 0) GetComponent<SpriteRenderer>().sprite = left;
            else if (moveX > 0) GetComponent<SpriteRenderer>().sprite = right;
            else GetComponent<SpriteRenderer>().sprite = center;
        }
        else if (hp == 0 && !dead_c) 
            StartCoroutine(Die());
    }
}
