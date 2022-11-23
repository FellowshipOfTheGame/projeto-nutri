using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrinhaTimer : MonoBehaviour
{


    Vector3 redScale;
    Sprite bar;
    SpriteRenderer SR;
    float sizeX;
    float sizeXfixed;

    // Start is called before the first frame update
    void Start()
    {
        sizeX = 1000.0f;
        SR = gameObject.GetComponent<SpriteRenderer>();
        bar = SR.sprite;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sizeX -= Time.deltaTime * 45.0f;
        sizeXfixed = sizeX;

        Debug.Log(sizeXfixed); 
        if(sizeXfixed < 0.0f)
        {
            Debug.Log("Terminar jogo aqui");
        }
        else
        {
            redScale = new Vector3(sizeXfixed,100f,1.0f);
        }
        transform.localScale = redScale;
    }

}
