using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : AbstractAutomaton {

	// Use this for initialization
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
		base.Start();
	}
	

	protected override void OnCantMove <T> (T component) {
		Debug.Log("can't move");
	}


}
