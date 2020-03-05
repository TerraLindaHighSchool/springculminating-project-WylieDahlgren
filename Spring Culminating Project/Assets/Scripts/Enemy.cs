using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    private GameObject player;

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
        transform.Translate(lookDirection * Time.deltaTime * speed);
        transform.Rotate(0, yAngle, 0);
        Debug.Log(yAngle);
    }
}
