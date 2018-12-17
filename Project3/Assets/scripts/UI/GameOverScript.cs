using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    public GameObject turnManager;

	// Use this for initialization
	void Start () {
		
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void RestartLevel()
    {
        Time.timeScale = 1;
        turnManager.GetComponent<TurnManager>().reset = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("title");
    }
}
