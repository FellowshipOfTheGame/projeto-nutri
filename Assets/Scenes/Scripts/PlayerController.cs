using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbPlayer;

    [SerializeField]
    float vel;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yVel = Input.GetAxis("Vertical") * vel;
        float xVel = Input.GetAxis("Horizontal") * vel;
        rbPlayer.velocity = new Vector2(xVel,yVel);

        if(rbPlayer.velocity.x > 0)
        {
            rbPlayer.transform.eulerAngles = new Vector3(0,0,0);
        }
        else if(rbPlayer.velocity.x < 0) // 0 doesn't change the horizontal flip rotation
        {
            rbPlayer.transform.eulerAngles = new Vector3(0,-180,0);
        }
    }
}
