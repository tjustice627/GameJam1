using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed;
    public float changeTime;

    Rigidbody2D rb;

    int direction = 1;
    float timer;
    public bool isCured = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (isCured)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate() {
        Vector2 position = rb.position;

        position.x = position.x + Time.deltaTime * speed * direction;

        rb.MovePosition(position);
    }

    public void Kill()
    {
        Destroy(gameObject);
    } 

    void OnCollisionEnter2D(Collision2D other) 
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null && !other.gameObject.CompareTag("Sword"))
        {
            player.ChangeHealth(-1);
        }
    }
}
