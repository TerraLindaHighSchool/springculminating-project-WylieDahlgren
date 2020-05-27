using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    private GameObject player;
    public int healthEnemy = 3;
    public int numOfEnemies = 3;
    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (transform.position - player.transform.position).normalized;
        float yAngle = Mathf.Atan2(lookDirection.x, lookDirection.z) * 180 / Mathf.PI;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Rotate(new Vector3 (0,yAngle - this.transform.rotation.eulerAngles.y + 180, 0));
        death();
        if (numOfEnemies == 0)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Projectile")
        {
            healthEnemy--;
            Destroy(other.gameObject);
        }
    }
    private void death()
    {
        if (healthEnemy <= 0)
        {
            Destroy(gameObject);
            numOfEnemies--;
        }
    }
}
