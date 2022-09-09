using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] FinishLineZoneScript finishLine;

    [SerializeField] public GameObject[] characters = new GameObject[2];
    [System.NonSerialized] public GameObject currentPlayer;


    [SerializeField]
    public int charSelection;
    void Awake() 
    {
       currentPlayer = Instantiate(characters[charSelection],new Vector3(0,0,0),Quaternion.identity);
       currentPlayer.GetComponent<playerStats>().finishLine = finishLine;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
