using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
 
    public GameObject fuscao;

    private static int kartLevel;
    public static bool hasKart;
    private static int points = 0;
    private static int barPoint;
    private static int multPoint;

    public static int maxKartLevel = 4;

    public static int GFOK = 0; //Good food on kart
    public static int FOK = 0; //Food on Kart

    public int GetPoints()
    {
        return points;
    }
    public int GetBarPoint()
    {
        return barPoint;
    }
    public int GetMultPoint()
    {
        return multPoint;
    }
    public  void SetKartLevel(int newLevel)
    {
        kartLevel = newLevel;
    }
    public  int GetKartLevel()
    {
        return kartLevel;
    }

    public int auxKartLevel;

    void Start()
    {
        kartLevel = 0;
        hasKart = false; //Debug purposes. I'll change it later -- Nevermind
        ResetStreak();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("KL: " + kartLevel);
        Debug.Log("Has Kart = " + hasKart);
        if (kartLevel >= maxKartLevel)
        {
            SpawnBeetle();
        }
    }

    public static void AddPoint() // Adds points accordingly to the mult value
    {
        if (hasKart)
        {
            points += multPoint;
            barPoint++;
            kartLevel++;
            kartLevel = Mathf.Clamp(kartLevel,0,maxKartLevel);
            if (barPoint > 8) // Magic number bro
            {
                multPoint++;
                if (multPoint <= 4)
                {
                    barPoint = 0;
                }
                /* Fix those damn magic numbers*/
                barPoint = Mathf.Clamp(barPoint,0,8);
                multPoint = Mathf.Clamp(multPoint,1,4);
            }
        }
    }

    public static void ResetStreak() //Streak becomes as the same as initial state
    {
        barPoint = 0;
        multPoint = 1;
    }

    public static void SoftReset() //Just the bar point got reseted
    {
        barPoint = 0;
    }

    public static void AddFoodToKart(int fType) // Had to transform the whole operation in a function
    {
        Debug.Log("Added FOOD");
        FOK++;
        if (fType == 0)
        {
            GFOK++;
        }
    }

    public void SetKartState(bool stating) // Barely used
    {
        hasKart = stating;
    }

    public bool GetKartState() // Barely used
    {
        return hasKart;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Kartzone")
        {
            Debug.Log("OK - Player + Kartzone");
            if(!hasKart)
            {
                hasKart = true;
            }
        }
        else if (other.gameObject.tag == "Finishline")
        {
            Debug.Log("OK - Player + finish line");
            if (hasKart && kartLevel >= maxKartLevel)
            {
                /* Summing up: It's all a reset*/
                SetKartLevel(0);
                hasKart = true;
                float percentageOnKart = ((float)GFOK)/((float)FOK); 
                Debug.Log("Percentage: " + percentageOnKart);
                points += multPoint * (int)percentageOnKart; // Jankie code, but it was what worked for this
                GFOK = 0;
                FOK = 0;
                kartLevel = 0;
                Debug.Log("Carrinho colocado");
                Destroy(fuscao);
            }
        }
    }

    void SpawnBeetle()
    {
        Instantiate(fuscao, new Vector3 (0,0,0) , Quaternion.identity);
    }
}
