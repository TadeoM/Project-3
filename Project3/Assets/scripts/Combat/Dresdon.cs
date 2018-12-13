using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dresdon : Creature {

	// Use this for initialization
	void Start () {
        currentTarget = GameObject.FindGameObjectWithTag("enemy");
    }
}
