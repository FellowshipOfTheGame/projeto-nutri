using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElemScript : MonoBehaviour
{
    [SerializeField] public List<Sprite> Img = new List<Sprite>();
    [SerializeField] public int imgindex;
    public GameObject auxChildImg;
    Image spriterenderer;
    // Start is called before the first frame update
    void Start()
    {
        //spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        //spriterenderer.sprite = Img[imgindex];
        auxChildImg = gameObject.transform.GetChild(1).gameObject;
        spriterenderer = auxChildImg.GetComponent<Image>();
        spriterenderer.sprite = Img[imgindex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
