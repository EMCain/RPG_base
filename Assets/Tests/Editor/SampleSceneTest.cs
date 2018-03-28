using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class SampleSceneTest {

	// declare anything that will be initialized in setup and used in multiple tests
	GameObject player; 
	GameObject enemy; 

	[SetUp]
	public void Setup() {
		EditorSceneManager.OpenScene(
			"Assets/Scenes/sample.unity", 
			OpenSceneMode.Single
		);
		player = GameObject.Find("Player"); 
		enemy = GameObject.Find("baddie1"); 
	}

	[Test]
	public void VerifySceneContents() {
		// for some reason, you have to do a == comparison to "null" rather than asserting "Is.Not.Null" for this assertion (that GameObject was found) to work properly. 
		Assert.That(player == null, Is.False, "Player GameObject was not found in scene"); 
		Assert.That(player.GetComponent<Player>(), Is.Not.Null, "Player GameObject did not have a Player component attached");

		Assert.That(enemy == null, Is.False, "Enemy GameObject was not found in scene"); 
		Assert.That(enemy.GetComponent<BasicEnemy>(), Is.Not.Null, "Enemy GameObject did not have a BasicEnemy component attached");
	}
}
