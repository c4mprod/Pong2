﻿using UnityEngine;
using System.Collections;

public class ScoringBorderScript : MonoBehaviour {

    public PlayerScript m_Player;
    public GameObject m_Spawner;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            this.m_Player.AddPoint();
           //this.m_Player.GetComponent<PlayerScript>().AddPoint();
           this.m_Spawner.GetComponent<SpawnerScript>().Spawn();
        }
    }
}
