using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class SampleSceneTest {

	[Test]
	public void VerifySceneContents() {
		EditorSceneManager.OpenScene(
			"Assets/Scenes/sample.unity", 
			OpenSceneMode.Single
		);
		GameObject player = GameObject.Find("Player"); 
		Assert.IsNotNull(player, "Player object was not found in scene!");
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator NewEditModeTest1WithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
