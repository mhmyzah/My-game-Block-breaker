using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Laser : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 0);
    }
    public void distroyLaser()
    {
        Destroy(gameObject);
    }
}
