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

    [SerializeField] public float border;

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
       // float auxM = beetle.transform.position.x - player.transform.position.x;
        //float auxA = beetle.transform.position.y - player.transform.position.y;
        
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
    }
}
