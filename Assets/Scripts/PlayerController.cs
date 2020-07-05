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
    [Header("Harpoon")]
    public GameObject PrefabHarpoon;
    private float timePressing;
    private bool isAttacking = false;

    void Start() 
    {
        speed2 = 0f;
        timePressing = 0f;
        target = new Vector2(0.0f, 0.0f);
    }

    void Update()
    {
        #region moviment
        if (Input.GetMouseButton(0))
        {
            target = Input.mousePosition;
            target = Camera.main.ScreenToWorldPoint(new Vector3(target.x, target.y, 0.0f));

            Vector2 direction = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
            transform.up = direction;
            transform.position = Vector2.MoveTowards(transform.position, target, speed * 2 * Time.deltaTime);
            speed2 = speed;
        }
        
        if (!isCollecting)
        {
            transform.Translate(0, speed2 * Time.deltaTime, 0);
        }
        #endregion

        if (Input.GetMouseButtonDown(1))
        {
            if (!isAttacking)
            {
                isAttacking = true;
                timePressing += Time.deltaTime;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {   
            if (isAttacking)
            {
                timePressing = Time.deltaTime - timePressing;
                target = Input.mousePosition;
                target = Camera.main.ScreenToWorldPoint(new Vector3(target.x, target.y, 0.0f));

                Vector2 direction = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
                GameObject harpoon = Instantiate(PrefabHarpoon, transform.position, transform.rotation);
                harpoon.transform.up = direction;
                
                HarpoonShot shot = harpoon.gameObject.GetComponent<HarpoonShot>();
                shot.force = timePressing;
                print(shot.force);
            }
        }
    }
}
