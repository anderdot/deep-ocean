using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfish : MonoBehaviour
{
    [Header("Starfish Settings")]
    public float speedRotation;
    private PlayerController player;
    private bool isAwaked = false; 

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            player = other.gameObject.GetComponent<PlayerController>();
            isAwaked = true;
        }
    }
    
    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (isAwaked)
        {
            transform.Rotate(0, 0, Time.deltaTime * speedRotation);

            float distance = Vector2.Distance(player.transform.position, transform.position);
            if (distance < 45)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 15f);
            }
            else
            {
                isAwaked = false;
            }
        }
    }
}
