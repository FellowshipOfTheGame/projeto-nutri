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

        difAux = 10.0f/(float)dif; //Temporary, have to find a function that optmizes the rate according to the difficulty in terms of level design

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
                bCannon[randy].GetComponent<SubCannonScript>().Shoot(dif);
                Debug.Log("Canhão de baixo: x: " + bCannon[randy].GetComponent<Transform>().position.x + " y: " + bCannon[randy].GetComponent<Transform>().position.y);
            break;
            case 1:
                uCannon[randy].GetComponent<SubCannonScript>().Shoot(dif);
                Debug.Log("Canhão de cima: x: " + uCannon[randy].GetComponent<Transform>().position.x + " y: " + uCannon[randy].GetComponent<Transform>().position.y);

            break;
            case 2:
                lCannon[randy].GetComponent<SubCannonScript>().Shoot(dif);
                Debug.Log("Canhão esquerdo: x: " + lCannon[randy].GetComponent<Transform>().position.x + " y: " + lCannon[randy].GetComponent<Transform>().position.y);
            break;
            case 3:
                rCannon[randy].GetComponent<SubCannonScript>().Shoot(dif);
                Debug.Log("Canhão direito: x: " + rCannon[randy].GetComponent<Transform>().position.x + " y: " + rCannon[randy].GetComponent<Transform>().position.y);

            break;
        }
    }
}
