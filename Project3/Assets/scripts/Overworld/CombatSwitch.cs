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
    public GameObject EnemyHealth;
    public float playerExp;

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
                if (enemies[i] != null && player != null)
                {
                    float distance = Vector3.Distance(player.transform.position, enemies[i].transform.position);
                    bool pMoving = player.GetComponent<PlayerMove>().moving;
                    bool eMoving = enemies[i].GetComponent<NPCMove>().moving;
                    
                    if (distance < 1.5f && !pMoving && !eMoving)
                    {
                        combatCamera.SetActive(true);
                        mainCamera.SetActive(false);
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
                        Debug.Log(currentEnemy);
                        Vector3 playerDelta = currentEnemy.transform.position - player.transform.position;
                        player.transform.rotation = Quaternion.LookRotation(playerDelta, Vector3.up);
                        Vector3 enemyDelta = player.transform.position - currentEnemy.transform.position;
                        currentEnemy.transform.rotation = Quaternion.LookRotation(enemyDelta, Vector3.up);
                        EnemyHealth.SetActive(true);
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

            if (player != null)
            {
                combatCamera.SetActive(false);
            }
            
            mainCamera.SetActive(true);
            EnemyHealth.SetActive(false);

            if (player != null)
            {
                player.GetComponent<PlayerMove>().enabled = true;
                player.GetComponent<Creature>().currentHealth = player.GetComponent<Creature>().MaxHealth;
                player.GetComponent<Creature>().CurrentMana = player.GetComponent<Creature>().MaxMana;
                player.GetComponent<Creature>().Ammo = player.GetComponent<Creature>().MaxAmmo;
            }
            

            inCombat = false;
            foreach (GameObject e in enemies)
            {
                if (e != null)
                {
                    e.GetComponent<NPCMove>().enabled = true;
                }
            }
            enemies.Remove(currentEnemy);
            if (player != null)
            {
                playerExp = (player.GetComponent<Creature>().Level - 1) * 50;
            }
            
            int rand = Random.Range(0, 2);
            GameObject enemyPrefab;
            GameObject newEnemy;
            Vector3 position;
            if (rand == 0)
            {
                position = new Vector3((float)Random.Range(0, 23) + 0.5f, 1.4f, (float)Random.Range(18, 21));
                enemyPrefab = ghoulPrefab;
            }
            else if (rand == 1)
            {
                position = new Vector3((float)Random.Range(0, 23) + 0.5f, 1.4f, (float)Random.Range(18, 21));
                enemyPrefab = goblinPrefab;
            }
            else
            {
                position = new Vector3((float)Random.Range(0, 23) + 0.5f, 1.4f, (float)Random.Range(18, 21));
                enemyPrefab = houndPrefab;
                
            }
            if (player != null)
            {
                newEnemy = Instantiate(enemyPrefab, position, Quaternion.identity);
                newEnemy.GetComponent<Creature>().IncreaseExperience(playerExp);
                enemies.Add(newEnemy);
            }
            
        }

    }
}
