using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    [SerializeField] GameObject[] pathArray;
    [SerializeField] float pithSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PathTrans();
    }

    // path baslangic pozisyonunu tutar.
    Vector3 pathStartPosition { get { return new Vector3(40, 0, 0); } }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = pathStartPosition;
        other.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    // pathin X ekseninde surekli kaymasini saglar.
    void PathPositionUpdate(GameObject path)
    {
        path.GetComponent<Rigidbody>().velocity = new Vector3(-pithSpeed, 0, 0);
    }

    // tum pathlere kaydirma islemi uygular.
    void PathTrans()
    {
        for (int i = 0; i < pathArray.Length; i++)
        {
            PathPositionUpdate(pathArray[i]);
        }
    }

}
