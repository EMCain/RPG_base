using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAutomaton : MovingObject {

	// Use this for initialization
	protected bool movingInPattern = true;
	protected Vector2[] pattern;
	protected int patternIndex = 0;
	protected virtual void Start () {
		moveTime = 0.75f;
		base.Start();
		StartCoroutine(moveInPattern());
	}
	protected IEnumerator moveInPattern() {
		while(movingInPattern) {
			Vector2 currentDirection = pattern[patternIndex];
			AttemptMove<Component>((int) currentDirection.x, (int) currentDirection.y);

			if (patternIndex == pattern.Length - 1) 
				patternIndex = 0;
			else
				patternIndex++;

			yield return new WaitForSeconds(moveTime); // you could pass it something different but the movement would appear jerky.
		}
	}

	
	// // Update is called once per frame
	// void Update () {
	// }

}
