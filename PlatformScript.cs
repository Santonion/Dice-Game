using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float jumpforce = 10.0f;  // Hur h�gt man hoppar
    public int maxBounces = 2;  // M�ngden studsningar innan plattformen f�rst�rs
    private int currentBounces = 0;  // M�ngden studsar

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

                currentBounces++;  // �kar antalet studsningar

                // �kar po�ngen n�r spelaren landar p� plattformen
                if (gameManager != null)
                {
                    gameManager.IncreaseScore(10);
                }

                if (currentBounces >= maxBounces)
                {
                    // F�rst�r plattformen om den har studsats p� innan
                    Destroy(gameObject);
                }
            }
        }
    }
}
