using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Image myImage;
    public Color myColor;
    // Start is called before the first frame update
    void Start()
    {

        gameObject.SetActive(false);
        myImage = gameObject.GetComponent<Image>();
        myColor = new Color(1.0f,1.0f,1.0f,0f);
        myImage.color = myColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeIn()
    {
        gameObject.SetActive(true);
        for(float alpha = 0f; alpha <= 1.0f; alpha += 0.1f)
        {
            myColor = new Color(1.0f,1.0f,1.0f,alpha);
            myImage.color = myColor;
            yield return new WaitForSeconds(0.01f);
        }

    }
}
