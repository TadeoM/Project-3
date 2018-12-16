using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUI : MonoBehaviour {

    public List<GameObject> abilities = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Select()
    {
        for (int i = 0; i < abilities.Count; i++)
        {
            if (abilities[i].activeSelf)
                abilities[i].SetActive(false);
            else
                abilities[i].SetActive(true);

        }
    }
}
