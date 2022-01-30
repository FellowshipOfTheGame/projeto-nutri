using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class makes the stage's difficulty customizable as
possible */

public class StagePlanner : MonoBehaviour
{

    

    [SerializeField]
    float[] stageTiming = new float[3];
    int actualStage;

    [SerializeField]
    int numFases;

    [SerializeField]
    float timing;

    // Start is called before the first frame update
    void Start()
    {
        actualStage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timing -= Time.deltaTime;
        if (timing < 0 && actualStage < numFases - 1)
        {
            actualStage++;
            timing = stageTiming[actualStage];
            Readjust();
        }
    }

    void Readjust()
    {
        //Debug.Log(" OK. ");
    }
}
