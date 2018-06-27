using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy ctrl.
/// Control the enemy behaviour
/// </summary>
public class EnemyCtrl : MonoBehaviour {

	public int ePower;			//Power of the enemy
	public GameObject enemy;


	// Check the colisions between enemy and cards
	void OnTriggerEnter2D(Collider2D other){
		switch (other.gameObject.tag) {
		case "Card": 
			GameCtrl.instance.CardContact (enemy);
			break;
		case "SpecialCard":
			GameCtrl.instance.SpecialCardContact (ePower);
			break;
		case "SpecialCard2":
			GameCtrl.instance.SpecialCardContact2 ();
			break;
			default:
			break;
		}
	}
}

