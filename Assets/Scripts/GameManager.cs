using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public GameObject canvas;

	public int maxCoins;
	public int maxHealth;

	public int coins;
	public int health;

	// public Player player;

	// Use this for initialization
	void Awake () {
		// enforce singleton pattern
		if (instance == null)
			instance = this;
		else if (instance != this) 
			Destroy(gameObject);

		// persist when loading scene 
		DontDestroyOnLoad(gameObject);

		// TODO look up existing values first, and only set to these if there aren't any
		maxCoins = 10;
		maxHealth = 5;

		// Debug.Log(SceneManager.GetActiveScene().name);

		if (!SceneManager.GetActiveScene().name.Contains("Menu")) {
		// 	// don't do any of this stuff on the UI-only screens

		// 	coins = 0;
		// 	health = maxHealth - 2;
		// 	GameObject playerObj = GameObject.FindGameObjectsWithTag("Player")[0];
		// 	Debug.Log(playerObj);
			
		// 	player = playerObj.GetComponent<Player>();

		// 	// GameObject[] canvases = GameObject.FindGameObjectsWithTag("StatsCanvas");

		// 	//canvas = canvases[0];
		canvas = GameObject.Find("StatsCanvas");
		Debug.Log(canvas);


			// for (int i = 0; i < canvases.Length; i++) {
			// 	if (canvases[i].GetComponent<Canvas>().isActiveAndEnabled)
			// 		canvas = canvases[i];
			// 	else {
			// 		Debug.Log(canvases[i]);
			// 		Debug.Log("not active"); 
			// 	}
			// }
			// Debug.Log(canvas);
		
		}
		// this is redundant but the health bit is important
		// if (player) {
		// 	if (health <= 0)
		// 		health = 3;

		// 	player.SetHealth(health);
		// 	player.SetCoins(coins);
		// }


	}
	
	// TODO have some level initation code.

	public void UpdatePlayerStats<T> (string name, T value) {
		// TODO check here if player dies, a win condition is satisfied, etc. 
		canvas.GetComponent<CanvasManager>().UpdateValue<T>(name, value);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
