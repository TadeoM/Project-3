using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoCont : MonoBehaviour {

    double timer;

    // Use this for initialization
    void Start()
    {
        timer = 6;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene("Title");
        }
    }
}
