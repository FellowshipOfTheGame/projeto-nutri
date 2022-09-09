
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLauncher : MonoBehaviour
{

    /* Stage customization*/
    [SerializeField]
    float[] stageTiming = new float[3]; // Need to make customizable sizes
    [SerializeField]
    int[] stageDif = new int[3];
    int actualStage;
    [SerializeField]
    int numFases;
    [SerializeField]
    float timing;
    [SerializeField] PlayerSpawner playerSpawner;




    int i; // C old habits

    public Camera cam;

    [Range(1, 10)]
    public int dif;

    [Range(0f, 10f)]
    public float difMagicalNumber;

    [SerializeField]
    public int numSubCannons;

    [SerializeField]
    public float margin;

    public GameObject selCannon; //Prefab on the GUI

    int rand;
    int randy; // Auxiliar of rand
    float difAux;


    List<GameObject> bCannon = new List<GameObject>();
    List<GameObject> uCannon = new List<GameObject>();
    List<GameObject> lCannon = new List<GameObject>();
    List<GameObject> rCannon = new List<GameObject>();
   

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        actualStage = 0; // MUST start at zero

        difAux = difMagicalNumber/(float)dif; //Temporary, have to find a function that optmizes the rate according to the difficulty in terms of level design

        /* Down bellow are some adjustments for transformation if the camera is moved*/
        /* Screen Resolution.*/
        float widRes = ((float) Screen.width);
        float heiRes = ((float) Screen.height); //Magic number. It needs more tests    

        /* Four corners coordinates*/
        float limLeft = cam.ScreenToWorldPoint(new Vector3(0.0f,0.0f,-10.0f)).x;
        float limBottom = cam.ScreenToWorldPoint(new Vector3(0.0f,0.0f,-10.0f)).y;
        float limRight = cam.ScreenToWorldPoint(new Vector3(widRes,0.0f,-10.0f)).x;
        float limUP = cam.ScreenToWorldPoint(new Vector3(0.0f,heiRes,-10.0f)).y;

        /* reassigning for Unity3d coordinates*/
        widRes = limRight - limLeft;
        heiRes = limUP - limBottom;

        /* Number of the initial coordinates for the cannons*/
        float initX = limLeft + (widRes/((float)numSubCannons * 2.0f)); 
        float initY = limBottom + (heiRes/((float)numSubCannons * 2.0f));



        /* 32 sub-cannons (8x4) is the default design choice, but I made it customizable using "serialize field"
            if you think a different number is a better design, be my guest
        */
        for(i = 0; i < numSubCannons; i++)
        {
            
            bCannon.Add( (GameObject) Instantiate(selCannon,new Vector3(initX + ( (float)i * (widRes/(float)numSubCannons ) ), 
            limBottom - margin, 0.0f ), Quaternion.AngleAxis(0, Vector3.forward ) ) );//Bottom
            uCannon.Add( (GameObject) Instantiate(selCannon,new Vector3(initX + ((float)i * (widRes/(float)numSubCannons) ), 
            limUP + margin, 0.0f), Quaternion.AngleAxis(180, Vector3.forward) ) );//UP
            lCannon.Add( (GameObject) Instantiate(selCannon,new Vector3(limLeft - margin, initY + ((float)i * (heiRes/(float)numSubCannons)), 
            0.0f), Quaternion.AngleAxis(270, Vector3.forward ) ) );//Left
            rCannon.Add( (GameObject) Instantiate(selCannon,new Vector3(limRight + margin, initY + ((float)i * (heiRes/(float)numSubCannons)), 
            0.0f), Quaternion.AngleAxis(90, Vector3.forward) ) );//Right
        }

        /* Setting for the following subcannons not to vary their launch position outside their axes*/
        for(i = 0; i < numSubCannons; i++)
        {
            bCannon[i].GetComponent<SubCannonScript>().setXLimit( (widRes/((float)numSubCannons * 2.0f) ) );
            uCannon[i].GetComponent<SubCannonScript>().setXLimit( (widRes/((float)numSubCannons * 2.0f) ) );
            lCannon[i].GetComponent<SubCannonScript>().setXLimit(0f);
            rCannon[i].GetComponent<SubCannonScript>().setXLimit(0f);

            bCannon[i].GetComponent<SubCannonScript>().setYLimit(0f);
            uCannon[i].GetComponent<SubCannonScript>().setYLimit(0f);
            lCannon[i].GetComponent<SubCannonScript>().setYLimit( (heiRes/((float)numSubCannons * 2.0f) ) );
            rCannon[i].GetComponent<SubCannonScript>().setYLimit( (heiRes/((float)numSubCannons * 2.0f) ) );

        }
        InvokeRepeating("CallForShooting",1.0f,difAux);

    }

    // Update is called once per frame
    void Update()
    {
        /* Difficulty changes if player spend too much time on a screen*/
        timing -= Time.deltaTime;
        if (timing < 0 && actualStage < numFases - 1)
        {
            actualStage++;
            timing = stageTiming[actualStage];
            dif = stageDif[actualStage];
            /* Trying to update the difficulty*/
            CancelInvoke();
            difAux = difMagicalNumber/((float)dif);
            InvokeRepeating("CallForShooting",1.0f,difAux);
            Debug.Log("Dif atual: "+ dif);
        }
    }

    void CallForShooting()
    {
        rand = Random.Range(0,4);
        randy = Random.Range(0,numSubCannons);
        
        //Debug.Log("randy = " + randy);
        /* Choose what cannon to do the shooting*/
        switch(rand)
        {
            case 0:
                if(bCannon[randy].GetComponent<SubCannonScript>().canShoot == 1)
                {
                    bCannon[randy].GetComponent<SubCannonScript>().Shoot(dif);
                    bCannon[randy].GetComponent<SubCannonScript>().SetCanShoot(0);
                }
                else
                {
                    bCannon[randy].GetComponent<SubCannonScript>().SetCanShoot(1);
                }
            break;
            case 1:
                if(uCannon[randy].GetComponent<SubCannonScript>().canShoot == 1)
                {
                    uCannon[randy].GetComponent<SubCannonScript>().Shoot(dif);
                    uCannon[randy].GetComponent<SubCannonScript>().SetCanShoot(0);

                }
                else
                {
                    uCannon[randy].GetComponent<SubCannonScript>().SetCanShoot(1);                    
                }
            break;
            case 2:
                if(lCannon[randy].GetComponent<SubCannonScript>().canShoot == 1)
                {
                    lCannon[randy].GetComponent<SubCannonScript>().Shoot(dif);
                    lCannon[randy].GetComponent<SubCannonScript>().SetCanShoot(0);

                }
                else
                {
                    lCannon[randy].GetComponent<SubCannonScript>().SetCanShoot(1);                    
                }
            break;
            case 3:
                if(rCannon[randy].GetComponent<SubCannonScript>().canShoot == 1)
                {
                    rCannon[randy].GetComponent<SubCannonScript>().Shoot(dif);
                    rCannon[randy].GetComponent<SubCannonScript>().SetCanShoot(0);

                }
                else
                {
                    rCannon[randy].GetComponent<SubCannonScript>().SetCanShoot(1);                    
                }
            break;
        }
    }
}
