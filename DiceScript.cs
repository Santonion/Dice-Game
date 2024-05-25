using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    public float Speed = 10.0f;  // Hastighet f�r r�relse
    public Rigidbody2D myrigidbody;  // Referens till Rigidbody2D-komponenten

    private float moveX;  // Variabel f�r horisontell r�relse

    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();  // H�mta Rigidbody2D-komponenten
        gameObject.name = "Dicepy";  // D�pa gameObjekt ett trevligt namn
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * Speed;  // H�mta horisontell inmatning
    }

    private void FixedUpdate()
    {
        Vector2 velocity = myrigidbody.velocity;
        velocity.x = moveX;  // �ndra horisontell hastighet
        myrigidbody.velocity = velocity;  // S�tt den nya hastigheten
    }
}