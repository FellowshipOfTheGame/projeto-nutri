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

    [SerializeField]
    public List<AudioClip> audioList = new List<AudioClip>();

    Sprite selectedSprite;
    int auxIndex;
    SpriteRenderer spriterenderer;

    [SerializeField] float lifetime;

    Rigidbody2D bulletRB;

    [SerializeField] float bulletSpeed;
    [SerializeField] FoodTypeNum foodType;

    public enum FoodTypeNum
    {
        InNatura,
        Processed,
        Ultra
    };

    public enum AudioType
    {
        GetItem,
        LevelUp,
        LevelDown,
        LevelZero  
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

        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerStats stats = other.gameObject.GetComponent<playerStats>();            
            /* Detects which type of food we will get*/
            switch(foodType)
            {
                case FoodTypeNum.InNatura:
                    stats.AddPoint();
                    stats.AddFoodToKart(foodType);
                    stats.PlaySound(audioList[(int)AudioType.GetItem]);                   
                break;

                case FoodTypeNum.Processed:
                    stats.SoftReset();
                    stats.AddFoodToKart(foodType);
                    stats.PlaySound(audioList[(int)AudioType.LevelDown]);
                break;

                case FoodTypeNum.Ultra:
                    stats.ResetMultiplier();
                    stats.AddFoodToKart(foodType);
                    stats.PlaySound(audioList[(int)AudioType.LevelZero]);                   
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
