using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float speedX = 13.0f;
    public float xRange = 30;
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -xRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -xRange);
        }
        if (transform.position.z > xRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, xRange);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if(Input.GetKey(KeyCode.R))
        {
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speedX);
            transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speedX);
        }
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }
}
