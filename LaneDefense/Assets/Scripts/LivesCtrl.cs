using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Lives ctrl.
/// Controls the behaviour of the lives
/// They change color every amount of secods 
/// and can only be destroyed by it's own color
/// </summary>
public class LivesCtrl : MonoBehaviour {

	public int lPower;				// decides which color to match  Green = 1, Red = 2, Green =3 
	public GameObject live;

	public float delay;				// delay for changing the color
	bool canChange;					// active the chaging color method
	SpriteRenderer sr;



	void Start(){
		sr = GetComponent<SpriteRenderer> ();			// get the sprite render from the object
		lPower = Random.Range (1, 4);					// set it's initial color by a random number
		canChange = true;
	} 

	void Update(){
		ChangeColor ();
	}

	/// <summary>
	/// Changes the color.
	/// Based on the numbers of the cards
	/// Green = 1, Red = 2, Green =3.
	/// </summary>
	void ChangeColor(){
		if (canChange) {
			canChange = false;
			if (lPower == 1) {
				sr.color = Color.green;
			} else if (lPower == 2) {
				sr.color = Color.red;
			} else if (lPower == 3) {
				sr.color = Color.yellow;
			}
		
			Invoke ("ChangePower", delay);
		}
	}

	// Gives the live a new number to change the color
	void ChangePower(){
		lPower = Random.Range (1, 4);
		canChange = true;
	}

	// Check the contact between the live and the cards
	void OnTriggerEnter2D(Collider2D other){
		switch (other.gameObject.tag) {
		case "Card": 
			GameCtrl.instance.UpdateLives (live);
			break;
		case "SpecialCard":
			Destroy (other.gameObject);
			break;
		case "SpecialCard2":
			Destroy (other.gameObject);
			break;
		default:
			break;
		}
	}


}
