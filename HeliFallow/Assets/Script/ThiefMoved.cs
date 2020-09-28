using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefMoved : MonoBehaviour
{
    LineChange lineChange;
    [SerializeField] float speed = 1f;
    Rigidbody rbThief;

    // Start is called before the first frame update
    void Start()
    {
        lineChange = gameObject.GetComponent<LineChange>();
        rbThief = GetComponent<Rigidbody>();
    }

    // thiefin hareket etmesini saglar
    void ThiefMove()
    {
        if (!lineChange.GetChangingLane())
        {
            rbThief.velocity = new Vector3(speed, 0, 0);
        }
        if (lineChange.GetChangingLane())
        {
            rbThief.velocity = new Vector3(speed, 0, lineChange.GetSpeedZ());
            if ((int)transform.position.z == lineChange.GetTargetPosZ())
            {
                lineChange.SetChangingLane(false);
                transform.position = new Vector3(transform.position.x, transform.position.y, lineChange.GetTargetPosZ());
            }
        }
        
    }//itewen

    private void Update()
    {
        ThiefMove();
    }
}
