using System.Collections;
using System.Collections.Generic;
using FoG.Scripts.UI;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] FinishLineZoneScript finishLine;

    [SerializeField] public GameObject[] characters = new GameObject[2];
    [System.NonSerialized] public GameObject currentPlayer;

    int CharSelection => Mathf.Clamp(CharacterSelection.GetPlayerSelected(), 0, characters.Length-1);
    
    void Awake()
    {
        currentPlayer = Instantiate(characters[CharSelection],new Vector3(0,0,0),Quaternion.identity);
        currentPlayer.GetComponent<playerStats>().finishLine = finishLine;
    }
}
