﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject target;
    public float lerpSpeed;
    public float slowMotion;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = slowMotion;
    }

    // Update is called once per frame
    void Update()
    {
        BulletShoot();
    }

    void BulletShoot()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * lerpSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Thief"))
        {
            Destroy(other.gameObject);
            Debug.Log("BOOOM");
        }
    }
}