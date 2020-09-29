using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceFollow : MonoBehaviour
{
    [SerializeField] GameObject upPath;
    [SerializeField] GameObject downPath;
    public float followDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Vector3 newPath = other.gameObject.transform.position;

        if (other.CompareTag("UpPath"))
        {
            Instantiate(upPath, new Vector3(followDistance, newPath.y, newPath.z), Quaternion.identity);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("DownPath"))
        {
            Instantiate(downPath, new Vector3(followDistance, newPath.y, newPath.z), Quaternion.identity);
            Destroy(other.gameObject);
        }
    }

}
