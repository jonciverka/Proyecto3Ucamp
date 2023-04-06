using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovientoEnemigoVolador : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer sprite;
    Vector3 velocity;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(new Vector2(9.8f*7f,9.8f*7f));
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = rigidbody2D.velocity;
        movimiento();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        var speed = velocity.magnitude;
        var direccion = Vector3.Reflect(velocity.normalized, other.contacts[0].normal);
        rigidbody2D.velocity = direccion * Mathf.Max(speed,0f);
    }
     private void movimiento(){
        if (velocity.x > 0){
            sprite.flipX = true;
        }
        if (velocity.x < 0){
            sprite.flipX = false;
        }
    }
}
