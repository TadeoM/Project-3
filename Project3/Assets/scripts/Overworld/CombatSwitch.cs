using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSwitch : MonoBehaviour {

    public GameObject player;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject combatCamera;
    public GameObject mainCamera;
    public GameObject combatManager;
    public GameObject combatUI;
    public bool inCombat;
    public GameObject currentEnemy;
    public GameObject ghoulPrefab;
    public GameObject goblinPrefab;
    public GameObject houndPrefab;

	// Use this for initialization
	void Start ()
    {
        inCombat = false;
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("enemy");

        foreach (var enemy in allEnemies)
        {
           enemies.Add(enemy);
        }

    }

    // Update is called once per frame
    void Update ()
    {
        if (!inCombat)
        {
            for (int i = 0; i < enemies.Count; i++)
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
                        this.GetComponent<TurnManager>().enabled = false;
                        combatManager.GetComponent<CombatManager>().enabled = true;
                        player.GetComponent<PlayerMove>().enabled = false;
                        inCombat = true;
                        foreach (GameObject e in enemies)
                        {
                            e.GetComponent<NPCMove>().enabled = false;
                        }
                       
                        combatManager.GetComponent<CombatManager>().enemy = enemies[i];
                        player.GetComponent<Creature>().currentTarget = enemies[i];
                        currentEnemy = enemies[i];
                    }
                }
            }
        }
        if (inCombat && combatManager.GetComponent<CombatManager>().finished)
        {
            combatUI.SetActive(false);
            this.GetComponent<TurnManager>().enabled = true;
            combatManager.GetComponent<CombatManager>().finished = false;
            combatManager.GetComponent<CombatManager>().winner = "nil";
            combatManager.GetComponent<CombatManager>().winner = "nil";
            combatManager.GetComponent<CombatManager>().takenTurn = false;
            combatManager.GetComponent<CombatManager>().enabled = false;
            combatManager.GetComponent<CombatManager>().firstRound = true;


            player.GetComponent<PlayerMove>().enabled = true;
            player.GetComponent<Creature>().currentHealth = player.GetComponent<Creature>().MaxHealth;
            player.GetComponent<Creature>().CurrentMana = player.GetComponent<Creature>().MaxMana;

            inCombat = false;
            foreach (GameObject e in enemies)
            {
                if (e != null)
                {
                    e.GetComponent<NPCMove>().enabled = true;
                }
            }
            enemies.Remove(currentEnemy);

            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                Vector3 position = new Vector3((float)Random.Range(-6, 17) + 0.5f, 1.4f, (float)Random.Range(18, 21));
                Instantiate(ghoulPrefab, position, Quaternion.identity);
            }
            else if (rand == 1)
            {
                Vector3 position = new Vector3((float)Random.Range(-6, 17) + 0.5f, 1.4f, (float)Random.Range(18, 21));
                Instantiate(goblinPrefab, position, Quaternion.identity);
            }
            else
            {
                Vector3 position = new Vector3((float)Random.Range(-6, 17) + 0.5f, 1.4f, (float)Random.Range(18, 21));
                Instantiate(houndPrefab, position, Quaternion.identity);
            }
        }

    }
}
