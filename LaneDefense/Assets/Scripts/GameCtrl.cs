using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour {

	public static GameCtrl instance;


	void Awake(){
		if (instance == null)
			instance = this;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// 
	/// <summary>
	/// Cards the contact.
	/// Check the power of the card and the enemy and destroy the enemy if the card has equals or
	/// more power than the enemy
	/// </summary>
	/// <param name="enemy">Enemy.</param>
	public void CardContact(GameObject enemy){
		if (GameObject.FindGameObjectWithTag ("Card").GetComponent<CardCtrl> ().cPower 
			>= GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyCtrl> ().ePower ) {
			
			Destroy (enemy);
		} 
	}
}
