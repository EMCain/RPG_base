using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

	public Text healthText;
	public Text coinText;
	 
	// Use this for initialization
	void Start () {

	}
	
	public void UpdateValue<T>(string name, T value) {
		switch (name) {
			case "health": 
				healthText.text = String.Format("health: {0}", value); 
				// TODO find a way to display current/ max health (max could be a variable on this object)
				break;
			case "coins": 
				coinText.text = String.Format("coins: {0}", value); 
				// TODO find a way to display current/ max health (max could be a variable on this object)
				break;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
