using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public Canvas canvas;

	public int maxCoins;
	public int maxHealth;

	public Player player;

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
		maxHealth = 5; // TODO start at 3, don't subtract when passing in to next line 

		player.SetHealth(maxHealth - 2);
		// TODO also coins--start at 0
	}
	
	// TODO have some level initation code.

	public void UpdatePlayerStats<T> (string name, T value) {
		// TODO check here if player dies, a win condition is satisfied, etc. 
		canvas.gameObject.GetComponent<CanvasManager>().UpdateValue<T>(name, value);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
