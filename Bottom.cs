using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomPlatformScript : PlatformScript
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D myrigidbody = collision.rigidbody;
            if (myrigidbody != null)
            {
                Vector2 velocity = myrigidbody.velocity;
                velocity.y = jumpforce;
                myrigidbody.velocity = velocity;

                // Ökar poängen när spelaren landar på plattformen
                if (gameManager != null)
                {
                    gameManager.IncreaseScore(10);
                }

                // Bottenplattformen förstörs inte
            }
        }
    }
}
