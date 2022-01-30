using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;


public class PewController : MonoBehaviour
{
    public Gamepad gp;
    public Rigidbody2D rb;

    [SerializeField]
    public float playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        gp = Gamepad.current;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moving = gp.leftStick.ReadValue();
        rb.velocity = moving * playerVelocity;
    }
}
