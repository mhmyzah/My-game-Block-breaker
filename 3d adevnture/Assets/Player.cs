using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 rot;
    // Start is called before the first frame update
    void Start()
    {
        rot = new Vector3(0, 0,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) { rot.z = rot.z + .1f;
            Debug.Log(rot.z);
        }
        // gameObject.transform.rotation.Set(Input.mousePosition.x, Input.mousePosition.y,0,0);
        gameObject.transform.position = rot;

      

    }
}
