using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 

public class bulletBehaviour : MonoBehaviour
{
    [SerializeField]
    float lifetime;

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
        lifetime -= Time.deltaTime;
        if(lifetime < 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
      
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("OK!!!!!");
            /* Detects which type of food we will get*/
            switch(foodType)
            {
                case FoodTypeNum.InNatura:
                    playerStats.AddPoint();
                    //playerStats.SetKartLevel(playerStats.GetKartLevel() + 1);
                break;

                case FoodTypeNum.Processed:
                    playerStats.SoftReset();
                break;

                case FoodTypeNum.Ultra:
                    playerStats.ResetStreak();
                break;

                default:
                    Debug.Log("Food Not found");
                break;
            }
        }
        Destroy(gameObject);
    }
}
