using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    public GameObject beetle;
    public GameObject player;
    public RectTransform myRectTransform;
    public Camera mainCamera;
    Vector3 scrToWrldPointBeetle;

    float aux = 0.1f;
    //public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        beetle = GameObject.Find("FinishLine");
        player = GameObject.FindWithTag("Player");
        myRectTransform = gameObject.GetComponent<RectTransform>();
        mainCamera = Camera.main;
        //scrToWrldPointBeetle = mainCamera.WorldToScreenPoint(beetle.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(beetle.transform.position,player.transform.position,Color.red,0f,false);
        float auxM = beetle.transform.position.x - player.transform.position.x;
        float auxA = beetle.transform.position.y - player.transform.position.y;
        /*float quickfixangles = 1.0f;
        if(auxM > 0.0f && ) // First Quadrant
        {

        }
        else if() // Se
        {

        }*/


        auxA = auxA/auxM;
        //auxA = Mathf.Atan(auxA) + quickfixangles;
        auxA = auxA * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f, auxA -90.0f); // ABNER, I USED THIS BECAUSE MY ARROW DRAWING WAS POINTING UP

        /* Change arrow position*/
        Vector3 scrToWrldPointBeetle = mainCamera.WorldToScreenPoint(beetle.transform.position);
        //Vector3 camBoundary = mainCamera.ScreenToWorldPoin(  );
        float margin = 40.0f;
        float xArrow = scrToWrldPointBeetle.x;
        xArrow = Mathf.Clamp(xArrow,margin,((Screen.width)) -margin);
        float yArrow = scrToWrldPointBeetle.y;
        yArrow = Mathf.Clamp(yArrow,margin,((Screen.height)) -margin);

        Debug.Log("X: " + xArrow + "Y: " + yArrow);

        myRectTransform.anchoredPosition = new Vector2 (xArrow,yArrow);
        //transform.position = new Vector3(xArrow,yArrow,0f);
    }
}
