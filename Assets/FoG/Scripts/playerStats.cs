using UnityEngine;
using System;

public class playerStats : MonoBehaviour
{
    [SerializeField]
    public AudioSource audiosource;

    public FinishLineZoneScript finishLine;
    [SerializeField] int MaxStreak = 5;
    [SerializeField] int MaxMultiplier = 5;

    public event Action<int> OnUpdateTotalPoints;
    public event Action<int> OnPointsRecieved;
    public event Action<int> OnUpdateStreak;
    public event Action<int> OnUpdateMultiplier;

    int kartLevel;
    bool hasKart;
    int points = 0;
    int streakCounter;
    int multPoint;
    int counterHoodOpened;
    float timeToAdd;

    public int maxKartLevel = 24;

    int GFOK = 0; //Good food on kart
    int FOK = 0; //Food on Kart

    int currentFoodLevel = 0;

    PewController playerController;

    public int Points
    {
        get => points;
        private set 
        {
            OnPointsRecieved?.Invoke(value - points);
            points = value;
            OnUpdateTotalPoints?.Invoke(points);
        }
    }
    public int StreakCounter
    {
        get => streakCounter;
        private set
        {
            streakCounter = value;
            OnUpdateStreak?.Invoke(streakCounter);
        }
    }
    public int MultPoint
    {
        get => multPoint;
        private set
        {
            multPoint = value;
            OnUpdateMultiplier?.Invoke(multPoint);
        }
    }
    public int KartLevel
    {
        get => kartLevel;
        set => kartLevel = value;
    }

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        counterHoodOpened = 0;
        kartLevel = 0;
        hasKart = true; //Debug purposes. I'll change it later -- Nevermind
        ResetMultiplier();
        playerController = GetComponent<PewController>();
    }

    public void AddPoint() // Adds points accordingly to the mult value
    {
        if (hasKart)
        {
            Points += MultPoint;
            StreakCounter++;
            if (StreakCounter > MaxStreak) 
            {
                MultPoint++;
                if (MultPoint < MaxMultiplier)
                {
                    StreakCounter = 0;
                }
                /* Fix those damn magic numbers*/
                StreakCounter = Mathf.Clamp(StreakCounter,0,MaxStreak);
                MultPoint = Mathf.Clamp(MultPoint,1,MaxMultiplier);
            }
        }
    }

    public void ResetMultiplier()
    {
        StreakCounter = 0;
        MultPoint = 1;
    }

    // Resets the streak counter. If on MaxMultiplier, decreases one multiplier level
    public void SoftReset()
    {
        StreakCounter = 0;
        if (MultPoint == MaxMultiplier)
        {
            MultPoint--;
        }
    }

    public void AddFoodToKart(bulletBehaviour.FoodTypeNum type) // Had to transform the whole operation in a function
    {
        Debug.Log("Added FOOD");
        FOK++;
        if (type == bulletBehaviour.FoodTypeNum.InNatura)
        {
            GFOK++;
        }
        
        kartLevel++;
        if (kartLevel == maxKartLevel)
        {
            OpenHood();
        }

        float foodLevel = FOK / (float) maxKartLevel;
        int expectedLevel = (int) Mathf.Min(foodLevel * 2, 2);
        if (expectedLevel >= currentFoodLevel)
        {
            currentFoodLevel = expectedLevel;
            playerController.UpdateKartFoodLevel(currentFoodLevel);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /* Feature not used :( */
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
                KartLevel = 0;
                hasKart = true;
                float percentageOnKart = ((float)GFOK)/((float)FOK) * 100; 
                Debug.Log("Percentage: " + percentageOnKart);
                Points += MultPoint * (int)percentageOnKart; // Jankie code, but it was what worked for this
                GFOK = 0;
                FOK = 0;
                kartLevel = 0;
                Debug.Log("Carrinho colocado");
                counterHoodOpened++;
                timeToAdd = percentageOnKart/(1 + Mathf.Log(counterHoodOpened,10)); // Check formula later
                timeToAdd += 3.0f;
                CloseHood(timeToAdd);
            }
        }
    }

    void OpenHood()
    {
        finishLine.OpenHood();
    }

    void CloseHood(float addingTimer)
    {
        finishLine.CloseHood();
        currentFoodLevel = 0;
        playerController.UpdateKartFoodLevel(currentFoodLevel);
        TimerTextManager.AddTimer(addingTimer);
    }

    public void PlaySound(AudioClip audioclip)
    {
        audiosource.clip = audioclip;
        audiosource.Play();
    }

}
