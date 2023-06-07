using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class arrowScript : MonoBehaviour
{
    public GameObject beetle;
    public GameObject player;
    public RectTransform myRectTransform;
    public Camera mainCamera;
    public Image myRenderer;
    Vector3 scrToWrldPointBeetle;
    bool offScreen;

    [SerializeField] public float border;

    float aux = 0.1f;
    //public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        beetle = GameObject.Find("FinishLine");
        player = GameObject.FindWithTag("Player");
        myRectTransform = gameObject.GetComponent<RectTransform>();
        myRenderer = gameObject.GetComponent<Image>();
        mainCamera = Camera.main;
        //scrToWrldPointBeetle = mainCamera.WorldToScreenPoint(beetle.transform.position);


    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(beetle.transform.position,player.transform.position,Color.red,0f,false);        
        Vector3 playerPointer = (beetle.transform.position - player.transform.position).normalized;

        float angle = Mathf.Atan2(playerPointer.y, playerPointer.x) * Mathf.Rad2Deg ;
        if (angle < 0) angle += 360;
        angle += 270;
        myRectTransform.localEulerAngles = new Vector3 (0,0,angle);

        scrToWrldPointBeetle = mainCamera.WorldToScreenPoint(beetle.transform.position);

        float xArrow = scrToWrldPointBeetle.x;
        float yArrow = scrToWrldPointBeetle.y;

        xArrow = Mathf.Clamp(xArrow,border,Screen.width - border);
        yArrow = Mathf.Clamp(yArrow,border,Screen.height - border);

        myRectTransform.anchoredPosition = new Vector2 (xArrow,yArrow);
        transform.position = new Vector3(xArrow,yArrow,0f);
        
        if(scrToWrldPointBeetle.x <= 0 || scrToWrldPointBeetle.x > Screen.width || scrToWrldPointBeetle.y <= 0 || scrToWrldPointBeetle.y > Screen.height)
        {
            offScreen = true;
        }
        else
        {
            offScreen = false;
        }

        Debug.Log("Beetle.x = " + scrToWrldPointBeetle.x + " Beetle.y = " + scrToWrldPointBeetle.y);

        myRenderer.enabled = offScreen;


    }
}
