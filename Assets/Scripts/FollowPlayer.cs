using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    public int steps;

    private Queue<Vector2> record = new Queue<Vector2>();
    private Vector3 lastRecord;

    // Update is called once per frame
    void FixedUpdate()
    {
        // record position of player
        record.Enqueue(new Vector2(player.transform.position.x, player.transform.position.y - .5f));

        // remove last position from the record and use it for the current position of the blob
        if (record.Count > steps)
        {
            this.transform.position = record.Dequeue();
        }
    }
}
