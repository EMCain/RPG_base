using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public GameObject canvas; // TODO type consistency
	public GameObject playerObj;
	public Player player; 

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

		// register the callback 
		SceneManager.sceneLoaded += SceneLoadCallback;

	}
	
	// TODO have some level initation code.

	void SceneLoadCallback(Scene scene, LoadSceneMode sceneMode) {
		if (!scene.name.Contains("Menu")) {
			canvas = GameObject.Find("StatsCanvas");

			Debug.Log("canvas is " + canvas.name);
			Debug.Log("Instance canvas is " + instance.canvas.name);
			playerObj = GameObject.Find("Player");
			Debug.Log("Player is " + playerObj.name);
			player = playerObj.GetComponent<Player>();
			player.SetHealth(3);
			player.SetCoins(0);
		}


	}

	public void UpdatePlayerStats<T> (string key, T value) {

		Debug.Log("status of " + key + " set to " + value.ToString() );
		// TODO check here if player dies, a win condition is satisfied, etc. 
		canvas.GetComponent<CanvasManager>().UpdateValue<T>(key, value);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
