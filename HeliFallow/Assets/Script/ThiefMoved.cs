using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefMoved : MonoBehaviour
{
    //LineChange lineChange;
    //[SerializeField] float speed;
    //Rigidbody rbThief;
    //
    //// Start is called before the first frame update
    //void Start()
    //{
    //    lineChange = gameObject.GetComponent<LineChange>();
    //    rbThief = GetComponent<Rigidbody>();
    //}
    //
    //private void FixedUpdate()
    //{
    //    ThiefMove();
    //}
    //
    //// thiefin hareket etmesini saglar
    //void ThiefMove()
    //{
    //    // duz bir hizada ilerlemesini saglar
    //    if (!lineChange.GetChangingLane())
    //    {
    //        rbThief.velocity = new Vector3(speed, 0, 0);
    //    }
    //    // serit degistirirken capraz ilerlemesini saglar
    //    if (lineChange.GetChangingLane())
    //    {
    //        rbThief.velocity = new Vector3(speed, 0, lineChange.GetSpeedZ());
    //
    //        // en alt seride gecmesini kontrol eder
    //        if (lineChange.GetTargetPosZ() < 0 && transform.position.z <= lineChange.GetTargetPosZ())
    //        {
    //            transform.position = new Vector3(transform.position.x, transform.position.y, (int)lineChange.GetTargetPosZ());
    //            lineChange.SetChangingLane(false);
    //        }
    //        // en ust seride gecmesini kontrol eder
    //        if (lineChange.GetTargetPosZ() > 0 && transform.position.z >= lineChange.GetTargetPosZ())
    //        {
    //            transform.position = new Vector3(transform.position.x, transform.position.y, (int)lineChange.GetTargetPosZ());
    //            lineChange.SetChangingLane(false);
    //        }
    //        // orta seritten en ust seride gecmesini kontrol eder
    //        if (lineChange.GetTargetPosZ() == 0 && lineChange.GetUpDirection() && transform.position.z >= lineChange.GetTargetPosZ())
    //        {
    //            transform.position = new Vector3(transform.position.x, transform.position.y, (int)lineChange.GetTargetPosZ());
    //            lineChange.SetChangingLane(false);
    //        }
    //        // orta seritten en alt seride gecmesini kontrol eder
    //        else if (lineChange.GetTargetPosZ() == 0 && !lineChange.GetUpDirection() && transform.position.z <= lineChange.GetTargetPosZ())
    //        {
    //            transform.position = new Vector3(transform.position.x, transform.position.y, (int)lineChange.GetTargetPosZ());
    //            lineChange.SetChangingLane(false);
    //        }
    //    }
    //    
    //}//itewen
}
