using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    public GameObject beetle;
    public GameObject player;
    float aux = 0.1f;
    //public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        beetle = GameObject.Find("FinishLine");
        player = GameObject.FindWithTag("Player");
        //camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(beetle.transform.position,player.transform.position,Color.red,0f,false);
        float auxM = beetle.transform.position.x - player.transform.position.x;
        float auxA = beetle.transform.position.y - player.transform.position.y;
        auxA = auxA/auxM;
        auxA = Mathf.Atan(auxA);
        auxA = auxA * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f, auxA -90.0f); // ABNER, I USED THIS BECAUSE MY ARROW DRAWING WAS POINTING UP
    }
}
