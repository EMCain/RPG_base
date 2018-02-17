using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject {

	private int coins;
	private int health;


	// Use this for initialization
	void Start () {
		// TODO get animator 
		// TODO get coins, health from GameManager 
		coins = 0;
		health = 5;

		base.Start();
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
}
