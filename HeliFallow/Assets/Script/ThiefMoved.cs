using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefMoved : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    Rigidbody rbThief;

    // Start is called before the first frame update
    void Start()
    {
        rbThief = GetComponent<Rigidbody>();
    }

    // thiefin hareket etmesini saglar
    void ThiefMove()
    {
        rbThief.velocity = new Vector3(speed, rbThief.velocity.y, rbThief.velocity.z);
    }

    private void FixedUpdate()
    {
        ThiefMove();
    }
}
