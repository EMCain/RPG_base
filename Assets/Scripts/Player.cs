using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject {

	private int coins;
	private int health;


	private int maxCoins;
	private int maxHealth;

	// Use this for initialization
	void Start () {
		// TODO get animator 
		// TODO get max coins, health from GameManager 
		maxCoins = GameManager.instance.maxCoins;
		maxHealth = GameManager.instance.maxHealth;

		base.Start();
	}
	
	public void SetHealth(int newHealth) {
		health = newHealth;
		GameManager.instance.UpdatePlayerStats<int>("health", health);
	}
	public void SetCoins(int newCoins) {
		coins = newCoins;
		GameManager.instance.UpdatePlayerStats<int>("coins", coins);
	}

	// Update is called once per frame
	void Update () {
		int horizontal = 0;
		int vertical = 0;

		horizontal = (int) Input.GetAxisRaw("Horizontal");
		vertical = (int) Input.GetAxisRaw("Vertical");	

		if (horizontal != 0 || vertical != 0) 
			AttemptMove<Component>(horizontal, vertical); // TODO define a class equivalent to Wall and put in <>
			
	}

	protected override void OnCantMove <T> (T component) {
		Debug.Log("can't move");
	}
	// TODO define a "restart" method to handle moves to other screens

	protected override void AttemptMove<T>(int xDir, int yDir) {
		base.AttemptMove<T>(xDir, yDir);
		RaycastHit2D hit;
		Move(xDir, yDir, out hit);
	}

	private void OnTriggerEnter2D (Collider2D other) {
		Token token = other.gameObject.GetComponent<Token>();
		if (token != null) {
			changeQty(token.tag, token.qty);
			Destroy(other.gameObject);
		}
	}

	private void changeQty (string type, int qty) {
		switch (type) {
			case "coin":
				int newCoins = coins + qty;
				if (newCoins > maxCoins)
					newCoins = maxCoins; 
				SetCoins(newCoins);
				break;
			case "health": 
				int newHealth = health + qty;
				if (newHealth > maxHealth)
					newHealth = maxHealth; 
				// TODO check if dead/game over -- perhaps in the GameManager
				SetHealth(newHealth);
				break;
		}

	}

}
