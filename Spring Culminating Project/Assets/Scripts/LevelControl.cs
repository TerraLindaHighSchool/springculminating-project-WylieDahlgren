using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public int numOfEnemies;
    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (numOfEnemies == 0)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
