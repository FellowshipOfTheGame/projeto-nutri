using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 

public class bulletBehaviour : MonoBehaviour
{
    Rigidbody2D bulletRB;

    [SerializeField]
    float bulletSpeed;
    // Start is called before the first frame update
    [SerializeField]
    FoodTypeNum foodType;

   public enum FoodTypeNum
    {
        InNatura,
        Processed,
        Ultra
    };

    void Start()
    {
        bulletRB = gameObject.GetComponent<Rigidbody2D>();
        bulletRB.velocity = transform.up * bulletSpeed; 
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
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("OK!!!!!");
            switch(foodType)
            {
                case FoodTypeNum.InNatura:
                    playerStats.AddPoint();
                break;

                case FoodTypeNum.Processed:
                    playerStats.ResetStreak();
                break;

                case FoodTypeNum.Ultra:
                    playerStats.SoftReset();
                break;

                default:
                    Debug.Log("Food Not found");
                break;
            }
        }
        Destroy(gameObject);
    }
}
