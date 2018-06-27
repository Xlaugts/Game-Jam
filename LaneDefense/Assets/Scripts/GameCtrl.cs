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
	public bool isPaused;						// active the pause menu
	public List <GameObject> specials;			// Holds the specials cards
	public Text txt_score,txt_score1 ;						// Holds the score txt
	public Text txt_lives,txt_lives1;						// Holds the lives txt

	public Slider specialbar;					// Holds the slice bar for the special
	public GameObject cardHolder;				// Get's the card holder gameobject
	public GameObject panel_GameOver;			// Holds the gameover panel
	public GameObject pause_Menu;				// holds the pause panel
	public GameObject btn_Pause;				// holds the pause button
	public GameObject BG_darker;



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

		if (isPaused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	// 
	/// <summary>
	/// Cards the contact.
	/// Check the power of the card and the enemy and destroy the enemy if the card has equals or
	/// more power than the enemy
	/// Add the score after the enemy is destroyed
	/// Increase the special bar or activate it after 5 enemies destroyed
	/// </summary>
	/// <param name="enemy">Enemy.</param>
	public void CardContact(GameObject enemy){
		if (GameObject.FindGameObjectWithTag ("Card").GetComponent<CardCtrl> ().cPower 
			== GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyCtrl> ().ePower ) {
			Destroyed (enemy,GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyCtrl> ().ePower);
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
	/// Destroy all enemies from the same color
	/// </summary>
	/// <param name="enemy">Enemy.</param>
	public void SpecialCardContact(int power){
		/*
		Destroyed (enemy, GameObject.FindGameObjectWithTag ("Enemy").GetComponent<EnemyCtrl> ().ePower);
		enemiesDestroyed += 1;
		activateS = 0;
		UpdateScore ();
		specialbar.value = (float)activateS;
		specialActive = false;
	*/
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		int e = enemies.Length;
		enemiesDestroyed += e;
		foreach (GameObject enemy in enemies) {
			int color = enemy.GetComponent<EnemyCtrl> ().ePower;
			if(power == color)
			Destroyed (enemy, color);
		}
		UpdateScore ();
		activateS = 0;
		specialbar.value = (float)activateS;
		specialActive = false;


	}


	/// <summary>
	/// Destroy all enemies from the scene
	/// </summary>
	public void SpecialCardContact2(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			int e = enemies.Length;
			enemiesDestroyed += e;
		foreach (GameObject enemy in enemies) {
			int color = enemy.GetComponent<EnemyCtrl> ().ePower;
			Destroyed (enemy, color);
		}
		UpdateScore ();
		activateS = 0;
		specialbar.value = (float)activateS;
		specialActive = false;

	}

	//Activate the special card every 5 enemies destroyed and deactivate after use it 
	void ActivateSpecial(){
		if (specialActive){
			specials [r].SetActive(true);
		} else
			specials [r].SetActive(false);
		
	}

	// Update the score 
	void UpdateScore(){
		txt_score.text = "Score: " + enemiesDestroyed;
		txt_score1.text = "Score: " + enemiesDestroyed;
	}


	// Check the lives
	public void CheckLives(GameObject enemy){
		lives--;
		if (lives >= 0) {
			txt_lives.text = " x" + lives;
			txt_lives1.text = " x" + lives;
		}
		if (lives >= 1) {
			Destroy (enemy);
		} else if (lives <= 0) {
			Destroy (enemy);
			cardHolder.SetActive (false);
			Invoke ("GameOver", 1.5f);
		}
		
	}

	// Call game over UI panel
	public void GameOver(){
		btn_Pause.SetActive (false);
		BG_darker.SetActive (true);
		panel_GameOver.SetActive (true);

	}


	// Method to destroy the enemies
	void Destroyed(GameObject enemy, int color){
		ExplosionColor (enemy.transform.position, color);

		Vector3 aPos = new Vector3 (enemy.transform.position.x, enemy.transform.position.y, -9f);
		AudioCtrl.instance.ContactExplosionAudio (aPos);
		Destroy (enemy);
	}

	// update the lives after collecting one 
	public void UpdateLives(GameObject heart){
		if (GameObject.FindGameObjectWithTag ("Card").GetComponent<CardCtrl> ().cPower
			== GameObject.FindGameObjectWithTag ("Lives").GetComponent<LivesCtrl> ().lPower) {
			Vector3 aPos = new Vector3 (heart.transform.position.x, heart.transform.position.y, -9f);
			AudioCtrl.instance.LifePickup (aPos);
			if (lives < 3) {
				lives += 1;
				txt_lives.text = " x" + lives;
				txt_lives1.text = " x" + lives;
			}
			Destroy (heart);
		}
	}

	public void ClickPause(){
		btn_Pause.SetActive (false);
		BG_darker.SetActive (true);
		pause_Menu.SetActive (true);
		isPaused = true;
	}

	public void ClickUnpause(){
		pause_Menu.SetActive (false);
		BG_darker.SetActive (false);
		btn_Pause.SetActive (true);
		isPaused = false;
	}

	/// <summary>
	/// Explosions the color.
	/// </summary>
	/// Get the explosion effect by comparing the power of the cards 
	/// and instantiating the right effect with the right color
	/// <param name="pos">Position.</param>
	/// <param name="color">Color.</param>
	void ExplosionColor(Vector3 pos, int color){
		if (color == 1) {
			SFXCtrl.instance.SFX_Explosion (pos, color-1);
		}else if (color == 2) {
			SFXCtrl.instance.SFX_Explosion (pos, color-1);
		} else if (color == 3) {
			SFXCtrl.instance.SFX_Explosion (pos, color-1);
		}
	}
		
}	

