using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class SpotController : MonoBehaviour
{
    public float speedModifier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        TouchControl();
    }

    // parmak konumuna gore spot isigi hareket eder.
    void TouchControl()
    {
        if (Input.GetMouseButton(0))
        {
            float h = speedModifier * Input.GetAxis("Mouse X") * -1;
            float v = speedModifier * Input.GetAxis("Mouse Y");

            this.transform.position = new Vector3(transform.position.x + v, transform.position.y, transform.position.z + h);
        }
    }
}
