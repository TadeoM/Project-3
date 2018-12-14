using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSwitch : MonoBehaviour {

    public GameObject player;
    public GameObject[] enemies;
    public GameObject combatCamera;
    public GameObject mainCamera;
    public GameObject combatManager;
    public GameObject combatUI;
    bool inCombat;

	// Use this for initialization
	void Start ()
    {
        inCombat = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!inCombat)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                float distance = Vector3.Distance(player.transform.position, enemies[i].transform.position);
                if (distance < 2.0f)
                {
                    //combatCamera.SetActive(true);
                    //mainCamera.SetActive(false);
                    combatUI.SetActive(true);
                    this.GetComponent<TurnManager>().enabled = false;
                    combatManager.GetComponent<CombatManager>().enabled = true;
                    player.GetComponent<PlayerMove>().enabled = false;
                    enemies[i].GetComponent<NPCMove>().enabled = false;
                    inCombat = true;
                }
            }
        }
       
    }
}
