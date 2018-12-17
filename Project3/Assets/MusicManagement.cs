using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagement : MonoBehaviour {
    public bool gameOver;
    public AudioSource overworld;
    public AudioSource combat;
    public AudioClip[] overWorldClips;
    public AudioClip[] combatClips;
    Dresdon player;
    CombatSwitch combatSwitcheroo;
    bool switched;
    float timer;
    // Use this for initialization
    void Start () {
        combatSwitcheroo = GetComponent<CombatSwitch>();
        overworld.clip = overWorldClips[0];
        overworld.volume = 1.0f;
        combat.volume = 0.0f;
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Dresdon>();
	}
	
	// Update is called once per frame
	void Update () {
        if (combatSwitcheroo.inCombat && combat.volume < 1.0f)
        {
            switched = false;
            if (player.currentTarget.layer == 9)
            {
                combat.clip = combatClips[2];
            }
            else
            {
                combat.clip = combatClips[0];
            }
            timer = combat.clip.length / 2.1f;
            overworld.volume -= 0.01f;
            combat.volume += 0.01f;
        }
        else if (!combatSwitcheroo.inCombat && overworld.volume < 0.95f)
        {
            overworld.volume += 0.01f;
            combat.volume -= 0.01f;
        }
        if(gameOver && overworld.volume < 1.0f)
        {
            overworld.clip = overWorldClips[1];
            overworld.Play();
            overworld.volume += 0.01f;
            combat.volume -= 0.01f;
        }
        if(combatSwitcheroo.inCombat && !switched)
        {
            timer -= 1 * Time.deltaTime;
            Debug.Log(timer);
            if (timer <= 0.0f)
            {
                if (player.currentTarget.layer == 9)
                {
                    combat.clip = combatClips[3];
                }
                else
                {
                    combat.clip = combatClips[1];
                }
                switched = true;
                combat.Play();
                combat.loop = true;
            }
        }
    }
}
