using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCannonScript : MonoBehaviour
{
    public int difficulty;
    public float vel;
    public float shooTime;
    public Transform firepoint;
    GameObject FP;

    public GameObject badFood;
    public GameObject neutralFood;
    public GameObject goodFood;
    

    // Start is called before the first frame update
    void Start()
    {
        FP = GameObject.Find("Firepoint");
        //firepoint = FP.GetComponentInChildren<Transform>() ;
        firepoint = transform;

        vel = (difficulty+1) * 3.0f; //Temporary, magic number for debugging and such.
        shooTime = 11.0f - (float)difficulty; // Probably useless
        //Debug.Log("I'm alive! - Pos x: " + transform.position.x + "Pos y: " + transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("Shoot",shooTime);
    }

  public void Shoot(int dif)
    {
        int auxDif = 0;
        /* Debugging function. Gotta change that*/
        if (dif < 4)
        {
            auxDif = 20; 
        }
        if(dif >= 4 && dif <= 7)
        {
            auxDif = 30;
        }
        else
        {  
            auxDif = 60;
        }
        
        int randy = Random.Range(0, 100);
        if (randy <= auxDif) //Neutral or bad item
        {
            if(randy%2 == 0)
            {
                //Debug.Log("Spawnar item ruim");
                Instantiate(badFood, firepoint.position, firepoint.rotation);
            }
            else
            {
                //Debug.Log("Spawnar item neutro");
                Instantiate(neutralFood, firepoint.position, firepoint.rotation);
            }
        }
        else
        {
            //Debug.Log("Spawnar item bom");
            Instantiate(goodFood, firepoint.position, firepoint.rotation);
        }
        //Debug.Log("vel = " + vel);
    }
}
