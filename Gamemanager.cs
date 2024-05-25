using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;  // Plattformsprefab
    public int platformCount = 300;  // Antal plattformar som skapas (kan l�tt �kas)
    private Vector3[] platformPositions;  // Positioner f�r plattformar
    public float platformSpawnRangeX = 3.0f;  // Omr�de f�r plattformsplacering p� X-axeln
    public Text scoreText;  // Referens till UI Text-komponenten

    private int score = 0;  // Po�ngvariabeln

    void Start()
    {
        platformPositions = new Vector3[platformCount];  // Array f�r plattformarnas positioner
        Vector3 spawnPosition = new Vector3();  // Position f�r plattformen
        float previousY = 0f;  // F�reg�ende Y-position

        for (int i = 0; i < platformCount; i++)  // Skapa plattformar
        {
            float newY = previousY + Random.Range(1.5f, 3.5f);  // Ny Y-position
            float newX = Random.Range(-platformSpawnRangeX, platformSpawnRangeX);  // Ny X-position

            spawnPosition.y = newY;  // Uppdatera Y-position
            spawnPosition.x = newX;  // Uppdatera X-position

            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);  // Skapa plattform

            platformPositions[i] = spawnPosition;  // Spara position
            previousY = newY;  // Uppdatera f�reg�ende Y-position
        }

    UpdateScoreText();  // Uppdatera po�ngen vid start
    }

    public void IncreaseScore(int amount)
    {
        score += amount;  // �ka po�ngen
        UpdateScoreText();  // Uppdatera po�ngen
    }

    public void DecreaseScore(int amount)
    {
        score -= amount;  // Minska po�ngen
        UpdateScoreText();  // Uppdatera po�ngen
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;  // Uppdatera po�ngen
        }
        else
        {
            Debug.LogError("ScoreText �r inte tilldelad!");
        }
    }
}
