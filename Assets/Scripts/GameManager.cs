using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public CanvasManager canvas; 
	public Player player; 

	public int maxCoins;
	public int maxHealth;

	private const int DEFAULT_COINS = 0;
	private const int DEFAULT_HEALTH = 3;

	private static Dictionary<string, int> playerStats = new Dictionary<string, int>();

	private string printStats() {
		// convenience method for debugging 
		string output = "player stats: { "; 
		foreach (KeyValuePair<string, int> p in playerStats) {
			output += p.Key + ": " + p.Value.ToString() + ", ";
		}
		output += "}";
		return output;
	}

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
		maxCoins = 15;
		maxHealth = 5;

		if (!playerStats.ContainsKey("coins"))
			playerStats["coins"] = DEFAULT_COINS;

		if (!playerStats.ContainsKey("health"))
			playerStats["health"] = DEFAULT_HEALTH;

		// register the callback 
		SceneManager.sceneLoaded += SceneLoadCallback;

	}
	
	// TODO have some level initation code.

	void SceneLoadCallback(Scene scene, LoadSceneMode sceneMode) {
		if (!scene.name.Contains("Menu")) {
			canvas = GameObject.Find("StatsCanvas").GetComponent<CanvasManager>();
			player = GameObject.Find("Player").GetComponent<Player>();
			player.SetHealth(playerStats["health"]);
			player.SetCoins(playerStats["coins"]);
		}
	}

	public void UpdatePlayerStats(string key, int value) {
		canvas.UpdateValue<int>(key, value);
		if (player.GetHealth() <= 0)
			PlayerDie();
	}

	public void SavePlayerState() {
		playerStats["health"] = player.GetHealth();
		playerStats["coins"] = player.GetCoins();
	}

	public void PlayerDie() {
		SavePlayerState();
		playerStats["health"] = DEFAULT_HEALTH;
		SceneManager.LoadScene("GameOverMenu");
	}
}
