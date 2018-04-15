using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour {

	public static GameCtrl instance;

	public int enemiesDestroyed;				// Count the enemies destroye. Add 1 for each enemy destroyed 
	public float reduceSpawnDelay;				// Amount of time that the spawn delay will reduce when an enemy is destroyed
	public EnemySpawner enemySpawner;			// Holds the EnemySpanwer script
	public bool canBeHarder;					// Alllow the game to be harder 
	public bool specialActive;					// Activate the special card 
	public GameObject speciaCard;				// Holds the Special card



	void Awake(){
		if (instance == null)
			instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ActivateSpecial ();
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
			== GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyCtrl> ().ePower ) {
			Destroy (enemy);
			enemiesDestroyed += 1;
			if ((enemiesDestroyed % 5) == 0 && enemiesDestroyed != 0)
				specialActive = true;
			if (canBeHarder) {
				if(enemySpawner.spawnDelay > 1.1f)
				enemySpawner.spawnDelay -= reduceSpawnDelay;
			}
		} 
	}

	/// <summary>
	/// Specials the card contact.
	/// The special card power
	/// </summary>
	/// <param name="enemy">Enemy.</param>
	public void SpecialCardContact(GameObject enemy){
			Destroy (enemy);
			enemiesDestroyed += 1;
		specialActive = false;

	}

	//Activate the special card every 5 enemies destroyed
	void ActivateSpecial(){
		if (specialActive)
			speciaCard.SetActive (true);
		else
			speciaCard.SetActive (false);
		
	}
}	

