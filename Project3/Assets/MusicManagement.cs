using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagement : MonoBehaviour {

    public AudioSource overworld;
    public AudioSource combat;
    public AudioClip[] combatClips;
    CombatSwitch combatSwitcheroo;
	// Use this for initialization
	void Start () {
        combatSwitcheroo = GetComponent<CombatSwitch>();
        overworld.volume = 1.0f;
        combat.volume = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(combatSwitcheroo.inCombat && combat.volume < 0.95f)
        {
            overworld.volume -= 0.01f;
            combat.volume += 0.01f;
        }
        else if (!combatSwitcheroo.inCombat && overworld.volume < 0.95f)
        {
            overworld.volume += 0.05f;
            combat.volume -= 0.05f;
        }
    }
}
