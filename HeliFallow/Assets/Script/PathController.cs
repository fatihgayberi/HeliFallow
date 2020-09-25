using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    [SerializeField] GameObject thief; // oyundaki tum pathler

    // path baslangic pozisyonunu tutar.
    Vector3 pathStartPosition { get { return new Vector3(Mathf.Floor(thief.transform.position.x) + 50f, 0f, 0f); } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Path")
        {
            other.transform.position = pathStartPosition;
        }
    }
}
