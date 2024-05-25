using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;  // Plattformsprefab
    public int platformCount = 300;  // Antal plattformar som skapas (kan lätt ökas)
    private Vector3[] platformPositions;  // Positioner för plattformar
    public float platformSpawnRangeX = 3.0f;  // Område för plattformsplacering på X-axeln
    public Text scoreText;  // Referens till UI Text-komponenten

    private int score = 0;  // Poängvariabeln

    void Start()
    {
        platformPositions = new Vector3[platformCount];  // Array för plattformarnas positioner
        Vector3 spawnPosition = new Vector3();  // Position för plattformen
        float previousY = 0f;  // Föregående Y-position

        for (int i = 0; i < platformCount; i++)  // Skapa plattformar
        {
            float newY = previousY + Random.Range(1.5f, 3.5f);  // Ny Y-position
            float newX = Random.Range(-platformSpawnRangeX, platformSpawnRangeX);  // Ny X-position

            spawnPosition.y = newY;  // Uppdatera Y-position
            spawnPosition.x = newX;  // Uppdatera X-position

            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);  // Skapa plattform

            platformPositions[i] = spawnPosition;  // Spara position
            previousY = newY;  // Uppdatera föregående Y-position
        }

    UpdateScoreText();  // Uppdatera poängen vid start
    }

    public void IncreaseScore(int amount)
    {
        score += amount;  // Öka poängen
        UpdateScoreText();  // Uppdatera poängen
    }

    public void DecreaseScore(int amount)
    {
        score -= amount;  // Minska poängen
        UpdateScoreText();  // Uppdatera poängen
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;  // Uppdatera poängen
        }
        else
        {
            Debug.LogError("ScoreText är inte tilldelad!");
        }
    }
}
