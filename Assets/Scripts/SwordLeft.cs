using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordLeft : MonoBehaviour
{
    public GameObject player;
    public int steps;

    private Queue<Vector2> record = new Queue<Vector2>();

    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Swing");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
    }
    void FixedUpdate()
    {
        // record position of player
        record.Enqueue(new Vector2(player.transform.position.x - .532f, player.transform.position.y - .263f));

        // remove last position from the record and use it for the current position of the blob
        if (record.Count > steps)
        {
            this.transform.position = record.Dequeue();
        }
    }
}
