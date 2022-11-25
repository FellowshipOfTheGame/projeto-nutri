using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UIButtonPress(int bType)
    {
        if(bType < 0)
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(bType);
        }
    }
}
