﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        ManagerGame.Singleton.SpawnPoints.Add(this);
	}
	

}
