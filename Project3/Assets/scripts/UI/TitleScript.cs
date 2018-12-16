using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour {
    /// set attribues
    
    public GameObject boardParent;
    public Vector3 boardPosition;
    Vector3 menuPosition;
    Vector3 missionPosition;
    Vector3 optionsPosition;
    Vector3 creditsPosition;
    Vector3 currStart;
    Vector3 currEnd;
    float fPercentage;
    public float startTime;
    public float distantTime;
    bool moving;

	// Use this for initialization
	void Start () {
        boardParent = GameObject.FindGameObjectWithTag("board");
        moving = false;
        boardPosition = new Vector3(2300, -840, 6);
        currStart = boardPosition;
        menuPosition = new Vector3(2300, -840, 6);
        missionPosition = new Vector3(-690, -840, 6);
        optionsPosition = new Vector3(-690, 1175, 6);
        creditsPosition = new Vector3(2300, 1175, 6);
        //boardPosition = new Vector3(540, -345, -726);
        //menuPosition = new Vector3(540, -345, -726);
        //missionPosition = new Vector3(-540, -345, -726);
        //optionsPosition = new Vector3(-540, 345, 726);
        //creditsPosition = new Vector3(540, 345, 726);
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (fPercentage < 1.0f && moving == true)
        {
            fPercentage = (Time.time - startTime) / distantTime;
            boardPosition = Vector3.Lerp(currStart, currEnd, fPercentage);
        }
        else if(fPercentage > 1.0f)
        {
            fPercentage = 1.0f;
            moving = false;
        }
        boardParent.transform.position = transform.localToWorldMatrix * boardPosition;
	}

    public void GoToMissionSelect()
    {
        moving = true;
        startTime = Time.time;
        fPercentage = 0.0f;
        currStart = menuPosition;
        currEnd = missionPosition;
    }

    public void GoToOptions()
    {
        moving = true;
        startTime = Time.time;
        fPercentage = 0.0f;
        currStart = menuPosition;
        currEnd = optionsPosition;
    }

    public void GoToCredits()
    {
        moving = true;
        startTime = Time.time;
        fPercentage = 0.0f;
        currStart = menuPosition;
        currEnd = creditsPosition;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GoToMenu()
    {
        moving = true;
        startTime = Time.time;
        fPercentage = 0;
        currStart = boardPosition;
        currEnd = menuPosition;
    }
    public void StartMission(string name)
    {
        Debug.Log("Starting Mission selected");
        SceneManager.LoadScene(name);
    }
}
