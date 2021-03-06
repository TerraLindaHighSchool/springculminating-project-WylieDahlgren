using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 50;
    public GameObject projectilePrefab;
    public float RotateSpeed = 30f;
    public float healthPlayer = 5;
    private GameObject enemy;
    public string mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            //transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            //transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -xRange)
        {
           //transform.position = new Vector3(transform.position.x, transform.position.y, -xRange);
        }
        if (transform.position.z > xRange)
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y, xRange);
        }
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
        verticalInput = Input.GetAxis("Vertical");
        if(verticalInput <= 0)
        {
            verticalInput = 0;
        }
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        Death();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hitbox")
        {
            healthPlayer--;
        }
    }
    private void Death()
    {
        if(healthPlayer <= 0)
        {
            SceneManager.LoadScene(mainMenu);
        }
    }
}
