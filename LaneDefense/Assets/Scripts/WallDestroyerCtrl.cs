using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Wall destroyer ctrl.
/// Controls the behaviour of the wall that destroy the enemies when triggers with it
/// </summary>
public class WallDestroyerCtrl : MonoBehaviour {



	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Enemy")){
			GameCtrl.instance.CheckLives (other.gameObject);
		
		}
		if(other.gameObject.CompareTag("Lives")){
			Destroy (other.gameObject);

		}
	}
}
