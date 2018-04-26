using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour {

	public int ePower;			//Power of the enemy
	public GameObject enemy;


	void OnTriggerEnter2D(Collider2D other){
		switch (other.gameObject.tag) {
		case "Card": 
			GameCtrl.instance.CardContact (enemy);
			break;
		case "SpecialCard":
			GameCtrl.instance.SpecialCardContact (enemy);
			break;
		case "SpecialCard2":
			GameCtrl.instance.SpecialCardContact2 ();
			break;
			default:
			break;
		}
	}
}

