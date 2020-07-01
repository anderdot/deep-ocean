using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollectResources : MonoBehaviour
{
    [Header("Item Settings")]
    public int id;
    public int count;
    public float timeToCollect = 1.5f;
    private float time;
    private PlayerController player;
    private bool isCollision;

    private void OnCollisionStay2D(Collision2D other) 
    {
        if (other.gameObject.tag.Equals("Player")) 
        {
            isCollision = true;

            float distance = Vector2.Distance(player.transform.position, transform.position);
            if (distance < 1)
            {
                player.isCollecting = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isCollision)
        {
            player = other.gameObject.GetComponent<PlayerController>();
            if (player.tag.Equals("Player") && player.isCollecting == false)
            {
                isCollision = true;
                Vector2 direction = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);
                player.transform.up = direction;
                player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, Time.deltaTime);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            isCollision = false;
            player.isCollecting = false;
        }
    }

    private void Start()
    {
        player = GetComponent<PlayerController>();
        time = timeToCollect;
    }

    private void Update()
    {
        if (isCollision)
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                print("Coletou " + this.name);
                Destroy(gameObject);
                player.isCollecting = false;
            }
        }
        else
        {
            time = timeToCollect;
        }
    }
}
