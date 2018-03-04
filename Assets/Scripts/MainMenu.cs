using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public void Continue() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		// TODO determine which scene should be loaded programatically 
	}

}
