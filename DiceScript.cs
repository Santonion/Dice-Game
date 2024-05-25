using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    public float Speed = 10.0f;  // Hastighet för rörelse
    public Rigidbody2D myrigidbody;  // Referens till Rigidbody2D-komponenten

    private float moveX;  // Variabel för horisontell rörelse

    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();  // Hämta Rigidbody2D-komponenten
        gameObject.name = "Dicepy";  // Döpa gameObjekt ett trevligt namn
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * Speed;  // Hämta horisontell inmatning
    }

    private void FixedUpdate()
    {
        Vector2 velocity = myrigidbody.velocity;
        velocity.x = moveX;  // Ändra horisontell hastighet
        myrigidbody.velocity = velocity;  // Sätt den nya hastigheten
    }
}