using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI multiplierText;
    [SerializeField] TextMeshProUGUI pointsEarned;

    [SerializeField] Image streakImage;
    [SerializeField] List<Sprite> flowerImages;

    [SerializeField] float pointsEarnedFadeDuration = 1f;

    float pointEarnedDynamicAlpha = 0;
    playerStats playerstats;

    void Awake()
    {
        var goPlayer = GameObject.Find("Player");
        playerstats = goPlayer.GetComponent<playerStats>(); 

        playerstats.OnUpdateTotalPoints += SetScore;
        playerstats.OnPointsRecieved += SetPointRecieved;
        playerstats.OnUpdateStreak += SetStreak;
        playerstats.OnUpdateMultiplier += SetMultiplier;

        ResetHUD();
    }

    void Update()
    {
        UpdatePointEarnedAlpha();
    }

    void UpdatePointEarnedAlpha()
    {
        if (pointEarnedDynamicAlpha <= 0) return;

        pointEarnedDynamicAlpha -= Time.deltaTime / pointsEarnedFadeDuration;
        pointsEarned.alpha = pointEarnedDynamicAlpha;
    }

    void ResetHUD()
    {
        SetScore(0);
        SetStreak(0);
        SetMultiplier(1);
        pointsEarned.alpha = 0;
    }

    void SetScore(int points)
    {
        // A string de 9 zeros indica que o número para representar pontos mostrará sempre 9 dígitos
        scoreText.text = points.ToString("000000000");
    }

    void SetStreak(int streak)
    {
        streak = Mathf.Clamp(streak, 0, flowerImages.Count - 1);
        streakImage.sprite = flowerImages[streak];
    }

    void SetMultiplier(int multiplier)
    {
        // Caso o multiplicador seja menor ou igual a 1, o texto deve ser vazio para não exibir na tela
        multiplierText.text = multiplier > 1 ? $"x{multiplier}" : "";
    }

    void SetPointRecieved(int points)
    {
        pointsEarned.text = $"+{points}";
        pointEarnedDynamicAlpha = 1f;
        pointsEarned.alpha = pointEarnedDynamicAlpha;
    }
}
