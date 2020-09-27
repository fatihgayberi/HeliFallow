using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefMoved : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    Rigidbody rbThief;

    // Start is called before the first frame update
    void Start()
    {
        rbThief = GetComponent<Rigidbody>();
    }

    // thiefin hareket etmesini saglar
    void ThiefMove()
    {
        rbThief.velocity = new Vector3(speed, 0, speed);
    }//itewen

    private void FixedUpdate()
    {
        ThiefMove();
    }
}
