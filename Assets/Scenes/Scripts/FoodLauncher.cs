
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLauncher : MonoBehaviour
{
    int i; // C old habits

    public Camera cam;

    [Range(1, 10)]
    public int dif;

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

        difAux = 1.0f/((float)dif * 2.0f); //Temporary, have to find a function that optmizes the rate according to the difficulty in terms of level design

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
        InvokeRepeating("CallForShooting",difAux,difAux);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("difAux: "+difAux);
    }

    void CallForShooting()
    {
        rand = Random.Range(0,4);
        randy = Random.Range(0,numSubCannons);
        
        Debug.Log("randy = " + randy);
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
