using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : AbstractAutomaton {

	// Use this for initialization
	public int damage;

	void Start () {
		pattern = new Vector2[] {
			new Vector2(1, 0),
			new Vector2(1, 0),
			new Vector2(1, 0),

			new Vector2(0, 1),

			new Vector2(-1, 0),
			new Vector2(-1, 0),
			new Vector2(-1, 0),

			new Vector2(0, -1),
		};
		damage = 1;
		base.Start();
	}
	
	public int DamageDealt() {
		// TODO make health and related numbers floats, not ints. 
		// in a more advanced enemy, this might be random or based on some factor.
		return 0-damage;
	}

	protected override void OnCantMove <T> (T component) {
		Debug.Log("can't move");
	}


}
