
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCannonScript : MonoBehaviour
{
    public int difficulty;
    public float vel;
    public float shooTime;
    public float xLimit;
    public float yLimit;


    public Transform firepoint;
    GameObject FP;

    public GameObject badFood;
    public GameObject neutralFood;
    public GameObject goodFood;

    public int canShoot;
    public Vector3 altVector;

    // Start is called before the first frame update
    void Start()
    {
        altVector = new Vector3 (0f,0f,0f);
        FP = GameObject.Find("Firepoint");
        firepoint = transform;

        vel = (difficulty+1) * 3.0f; //Temporary, magic number for debugging and such.
        shooTime = 11.0f - (float)difficulty; // Probably useless

        canShoot = 1;
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
        /* Need to do some game design research*/
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
        
        /* Other randoms. One for deciding if it's  a goodie or a baddie food
            The other is just for deciding the variation of spawning in the axis
        */
        int takingChances = Random.Range(0, 100);
        float varX = Random.Range(-xLimit,xLimit);
        float varY = Random.Range(-yLimit,yLimit);

        altVector = new Vector3(firepoint.position.x + varX, firepoint.position.y + varY, firepoint.position.z);

        if (takingChances <= auxDif) //Neutral or bad item
        {
            if(takingChances%2 == 0)
            {
                Instantiate(badFood, altVector, firepoint.rotation);
            }
            else
            {
                Instantiate(neutralFood, altVector, firepoint.rotation);
            }
        }
        else
        {
            Instantiate(goodFood, firepoint.position, firepoint.rotation);
        }
    }

    public void SetCanShoot(int opt)
    {
        canShoot = opt;
    }

    public void setXLimit(float lim)
    {
        xLimit = lim;
    }

    public void setYLimit(float lim)
    {
        yLimit = lim;
    }
}
