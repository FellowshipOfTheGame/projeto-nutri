using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    Rigidbody2D bulletRB;

    [SerializeField]
    float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = gameObject.GetComponent<Rigidbody2D>();
        bulletRB.velocity = transform.up * bulletSpeed; 
        //transform.localRotation = ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
      
    }


    void OnCollisionEnter2D(Collision2D other)
    {
            
    }
}
