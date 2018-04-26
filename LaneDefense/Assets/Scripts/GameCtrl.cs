using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;				// this give access to the unity UI elements


public class GameCtrl : MonoBehaviour {

	public static GameCtrl instance;

	public int lives;							// Number of lives
	public int enemiesDestroyed;				// Count the enemies destroye. Add 1 for each enemy destroyed 
	public float reduceSpawnDelay;				// Amount of time that the spawn delay will reduce when an enemy is destroyed
	public EnemySpawner enemySpawner;			// Holds the EnemySpanwer script
	public bool canBeHarder;					// Alllow the game to be harder 
	public bool specialActive;					// Activate the special card 
	public List <GameObject> specials;			// Holds the specials cards
	public Text txt_score;						// Holds the score txt
	public Text txt_lives;						// Holds the lives txt
	public Slider specialbar;					// Holds the slice bar for the special
	public GameObject cardHolder;				// Get's the card holder gameobject
	public GameObject panel_GameOver;			// Holds the gameover panel


	int activateS;								// Use to increase the special bar
	int r;										// Get's a random number to actvate one of the specials

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
			Destroyed (enemy);
			enemiesDestroyed += 1;
			activateS ++;
			specialbar.value = (float) activateS;
			UpdateScore ();
			if (activateS == 5) {
				r = Random.Range (0, 2);
				specialActive = true;
				SFXCtrl.instance.SpecialEnableSFX (specials [r].transform.position);
				Vector3 aPos = new Vector3 (cardHolder.transform.position.x, cardHolder.transform.position.y, -9f);
				AudioCtrl.instance.SpecialEnableSound(aPos);
			}
			if (canBeHarder) {
				if(enemySpawner.spawnDelay >0.8f) // Max difficult the game can be
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
		Destroyed (enemy);
		enemiesDestroyed += 1;
		activateS = 0;
		UpdateScore ();
		specialbar.value = (float)activateS;
		specialActive = false;

	}

	public void SpecialCardContact2(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			int e = enemies.Length;
			enemiesDestroyed += e;
		foreach (GameObject enemy in enemies) {
			Destroyed (enemy);
		}
		UpdateScore ();
		activateS = 0;
		specialbar.value = (float)activateS;
		specialActive = false;

	}

	//Activate the special card every 5 enemies destroyed
	void ActivateSpecial(){
		if (specialActive){
			specials [r].SetActive(true);
		} else
			specials [r].SetActive(false);
		
	}

	void UpdateScore(){
		txt_score.text = "Score: " + enemiesDestroyed;
	}

	public void CheckLives(GameObject enemy){
		lives--;
		if(lives >= 0)
		txt_lives.text = " x" + lives;
		if (lives >= 1) {
			Destroy (enemy);
		} else if (lives <= 0) {
			Destroy (enemy);
			cardHolder.SetActive (false);
			Invoke ("GameOver", 1.5f);
		}
		
	}

	public void GameOver(){
		panel_GameOver.SetActive (true);

	}

	void Destroyed(GameObject enemy){
		SFXCtrl.instance.CardsExplosion (enemy.transform.position);
		Vector3 aPos = new Vector3 (enemy.transform.position.x, enemy.transform.position.y, -9f);
		AudioCtrl.instance.ContactExplosionAudio (aPos);
		Destroy (enemy);
	}


	public void UpdateLives(GameObject heart){
		if (GameObject.FindGameObjectWithTag ("Card").GetComponent<CardCtrl> ().cPower
			== GameObject.FindGameObjectWithTag ("Lives").GetComponent<LivesCtrl> ().lPower) {
			Vector3 aPos = new Vector3 (heart.transform.position.x, heart.transform.position.y, -9f);
			AudioCtrl.instance.LifePickup (aPos);
			if (lives < 3) {
				lives += 1;
				txt_lives.text = " x" + lives;
			}
			specialActive = false;
			Destroy (heart);
		}
	}
}	

