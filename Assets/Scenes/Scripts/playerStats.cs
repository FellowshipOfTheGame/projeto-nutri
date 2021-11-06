using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    private static int points;
    private static int barPoint;
    private static int multPoint;

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


    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        barPoint = 0;
        multPoint = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddPoint() // Adds points accordingly to the mult value
    {
        points += multPoint;
        barPoint++;
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

    public static void ResetStreak()
    {
        barPoint = 0;
        multPoint = 1;
    }

    public static void SoftReset() //for tests only
    {
        barPoint = 0;
    }
}
