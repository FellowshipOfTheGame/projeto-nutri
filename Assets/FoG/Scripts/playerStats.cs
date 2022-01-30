using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
 
    private static int kartLevel;
    
    public bool hasKart;

    private static int points = 0;
    private static int barPoint;
    private static int multPoint;

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

    /*public int Points
    {
        get => points;
        set => points = value;
    }

    public int BarPoint
    {
        get => barPoint;
        set => barPoint = value;
    }

    public float MultPoint
    {
        get => multPoint;
        set => multPoint = value;
    }*/

    public int auxKartLevel;

    void Start()
    {
        kartLevel = 0;
        hasKart = false;
        ResetStreak();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("KL: " + kartLevel);
        Debug.Log("Has Kart = " + hasKart);
    }

    public static void AddPoint() // Adds points accordingly to the mult value
    {
        points += multPoint;
        barPoint++;
        kartLevel++;
        kartLevel = Mathf.Clamp(kartLevel,0,8);
        /* */
        if (barPoint > 8) 
        {
            multPoint++;
            if (multPoint <= 4)
            {
                barPoint = 0;
            }
            barPoint = Mathf.Clamp(barPoint,0,8);
            multPoint = Mathf.Clamp(multPoint,1,4);
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
}
