using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagement : MonoBehaviour {

    public AudioSource overworld;
    public AudioSource combat;
    public AudioClip[] combatClips;
    CombatSwitch combatSwitcheroo;
    float timer;
    bool switched;

	// Use this for initialization
	void Start () {
        combatSwitcheroo = GetComponent<CombatSwitch>();
        overworld.volume = 1.0f;
        combat.volume = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(combatSwitcheroo.inCombat && combat.volume < 1.0f)
        {
            switched = false;
            combat.clip = combatClips[0];
            timer = combat.clip.length / 2.1f;
            overworld.volume -= 0.01f;
            combat.volume += 0.01f;
        }
        else if (!combatSwitcheroo.inCombat && overworld.volume < 1.0f)
        {
            overworld.volume += 0.05f;
            combat.volume -= 0.05f;
        }
        if(combatSwitcheroo.inCombat && !switched)
        {
            timer -= 1 * Time.deltaTime;
            Debug.Log(timer);
            if (timer <= 0.0f)
            {
                combat.clip = combatClips[1];
                switched = true;
                combat.Play();
            }
        }
        //audio.clip = engineStartClip;
        //audio.Play();
        //yield return new WaitForSeconds(audio.clip.length);
        //audio.clip = engineLoopClip;
        //audio.Play();

    }
}
