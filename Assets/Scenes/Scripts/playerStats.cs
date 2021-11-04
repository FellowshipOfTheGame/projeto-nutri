using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    private int points;
    private int barPoint;
    private float multPoint;

    public int Points
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
    }


    // Start is called before the first frame update
    void Start()
    {
        this.points = 0;
        this.barPoint = 0;
        this.multPoint = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
