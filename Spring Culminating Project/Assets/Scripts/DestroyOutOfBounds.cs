using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float bound = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > bound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -bound)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > bound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -bound)
        {
            Destroy(gameObject);
        }
    }
}
