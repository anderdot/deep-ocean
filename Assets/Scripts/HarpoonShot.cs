using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class HarpoonShot : MonoBehaviour
{
    [Header("Harpoon Settings")]
    public float speed;
    public float force;

    private void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
