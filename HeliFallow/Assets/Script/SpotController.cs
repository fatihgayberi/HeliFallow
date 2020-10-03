using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class SpotController : MonoBehaviour
{
    public float speedModifier;
    public float spootVelocity;
    Rigidbody rbSpot;

    // Start is called before the first frame update
    void Start()
    {
        rbSpot = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        TouchControl();
    }

    private void FixedUpdate()
    {
        SpotPositonUpdate();
    }

    // parmak konumuna gore spot isigi hareket eder.
    void TouchControl()
    {
        if (Input.GetMouseButton(0))
        {
            float h = speedModifier * Input.GetAxis("Mouse X");
            float v = speedModifier * Input.GetAxis("Mouse Y");

            this.transform.position = new Vector3(transform.position.x + h, transform.position.y, transform.position.z + v);
        }
    }

    // spot isiginin aracin arkasina dusmemesi icin hareket etmesini saglar.
    void SpotPositonUpdate()
    {
        rbSpot.velocity = new Vector3(0f, 0f, spootVelocity);
    }
}
