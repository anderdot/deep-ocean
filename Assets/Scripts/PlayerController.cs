using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Moviment Settings")]
    public float speed;
    private float speed2;
    private Vector2 target;

    [Header("Inventory Settings")]
    public bool isCollecting = false;

    void Start() 
    {
        speed2 = 0f;
        target = new Vector2(0.0f, 0.0f);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            target = Input.mousePosition;
            target = Camera.main.ScreenToWorldPoint(new Vector3(target.x, target.y, 0.0f));

            Vector2 direction = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
            transform.up = direction;
            transform.position = Vector2.MoveTowards(transform.position, target, speed * 2 * Time.deltaTime);
            speed2 = speed;
        }
        
        if (isCollecting == false)
        {
            transform.Translate(0, speed2 * Time.deltaTime, 0);
        }
    }
}
