using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float jumpforce = 10.0f;  // Hur högt man hoppar
    public int maxBounces = 2;  // Mängden studsningar innan plattformen förstörs
    private int currentBounces = 0;  // Mängden studsar

    private GameManager gameManager;  // Referens till GameManager

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();  // Hitta GameManager i scenen
        if (gameManager == null)
        {
            Debug.LogError("GAMEMANEGER NOT FOUND :(");  // Om GamemManeger inte hittas
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D myrigidbody = collision.rigidbody;
            if (myrigidbody != null)
            {
                Vector2 velocity = myrigidbody.velocity;
                velocity.y = jumpforce;
                myrigidbody.velocity = velocity;

                currentBounces++;  // Ökar antalet studsningar

                // Ökar poängen när spelaren landar på plattformen
                if (gameManager != null)
                {
                    gameManager.IncreaseScore(10);
                }

                if (currentBounces >= maxBounces)
                {
                    // Förstör plattformen om den har studsats på innan
                    Destroy(gameObject);
                }
            }
        }
    }
}
