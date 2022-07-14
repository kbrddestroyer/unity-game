using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI_Button : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Scene level;

    void Start()
    {
            
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
