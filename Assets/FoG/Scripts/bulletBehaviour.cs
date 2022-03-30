using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bulletBehaviour : MonoBehaviour
{
    /* Sprite management*/
    [SerializeField]
    public List<Sprite> goodImges = new List<Sprite>();

    [SerializeField]
    public List<Sprite> badImges = new List<Sprite>();

    [SerializeField]
    public List<Sprite> neutralImges = new List<Sprite>();

    [SerializeField]
    public Sprite failSprite;

    Sprite selectedSprite;
    int auxIndex;
    SpriteRenderer spriterenderer;

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
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();

        switch(foodType)
        {
            case FoodTypeNum.InNatura:
                auxIndex = (int) (Random.Range(0, goodImges.Count));
                selectedSprite = goodImges[auxIndex];
            break;

            case FoodTypeNum.Processed:
                auxIndex = (int) (Random.Range(0, neutralImges.Count));
                selectedSprite = neutralImges[auxIndex];
            break;

            case FoodTypeNum.Ultra:
                auxIndex = (int) (Random.Range(0, badImges.Count));
                selectedSprite = badImges[auxIndex];
            break;

            default:
                Debug.Log("Something went wrong, check it again (due to timing?)"); // Default value is zero
                selectedSprite = failSprite;
            break;
        }

        ChangeSprite(selectedSprite, spriterenderer);
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
                    playerStats.AddFoodToKart(0);
                break;

                case FoodTypeNum.Processed:
                    playerStats.SoftReset();
                    playerStats.AddFoodToKart(1);
                break;

                case FoodTypeNum.Ultra:
                    playerStats.ResetStreak();
                    playerStats.AddFoodToKart(1);
                break;

                default:
                    Debug.Log("Food Not found");
                break;
            }
            Destroy(gameObject);
        }
    }

    void ChangeSprite(Sprite selectSprite, SpriteRenderer srender) // Selects a Sprite and renders it
    {
        srender.sprite = selectSprite;
    }


    public void SetType(FoodTypeNum typeFoodSet) // Good or bad food, you decide
    {
        foodType = typeFoodSet;
    }
}
