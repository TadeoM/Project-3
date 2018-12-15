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
    public bool inCombat;

	// Use this for initialization
	void Start ()
    {
        inCombat = false;
        enemies = GameObject.FindGameObjectsWithTag("enemy");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!inCombat)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] != null)
                {
                    float distance = Vector3.Distance(player.transform.position, enemies[i].transform.position);
                    bool pMoving = player.GetComponent<PlayerMove>().moving;
                    bool eMoving = enemies[i].GetComponent<NPCMove>().moving;
                    if (distance < 1.5f && !pMoving && !eMoving)
                    {
                        //combatCamera.SetActive(true);
                        //mainCamera.SetActive(false);
                        combatUI.SetActive(true);
                        //this.GetComponent<TurnManager>().enabled = false;
                        combatManager.GetComponent<CombatManager>().enabled = true;
                        player.GetComponent<PlayerMove>().enabled = false;
                        inCombat = true;
                        foreach (GameObject e in enemies)
                        {
                            e.GetComponent<NPCMove>().enabled = false;
                        }
                    }
                }
            }
        }
        if (inCombat && combatManager.GetComponent<CombatManager>().finished)
        {
            combatUI.SetActive(false);
            //this.GetComponent<TurnManager>().enabled = true;
            combatManager.GetComponent<CombatManager>().enabled = false;
            player.GetComponent<PlayerMove>().enabled = true;
            inCombat = false;
            foreach (GameObject e in enemies)
            {
                if (e != null)
                {
                    e.GetComponent<NPCMove>().enabled = true;
                }
            }
        }

    }
}
