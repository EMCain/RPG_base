using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MovingObject {

	private int coins;
	private int health;


	private int maxCoins;
	private int maxHealth;

	// Use this for initialization
	void Start () {
		maxCoins = GameManager.instance.maxCoins;
		maxHealth = GameManager.instance.maxHealth;
		base.Start();
	}
	
	public void SetHealth(int newHealth) {
		health = newHealth;
		GameManager.instance.UpdatePlayerStats("health", health);
	}
	public void SetCoins(int newCoins) {
		coins = newCoins;
		GameManager.instance.UpdatePlayerStats("coins", coins);
	}

	public int GetCoins() {
		return coins; 
	}

	public int GetHealth() {
		return health;
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
			return;
		}

		BasicEnemy enemy = other.gameObject.GetComponent<BasicEnemy>();
		if (enemy != null) {
			Vector3 away = gameObject.transform.position - enemy.transform.position;
			AttemptMove<Component>((int) away.x, (int) away.y);
			changeQty("health", enemy.DamageDealt());

			return;
		}

		// TODO create a base AbstractEnemy that inherits off the AbstractAutomaton class so that we can check against that 
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
				SetHealth(newHealth);
				break;
		}

	}

}
