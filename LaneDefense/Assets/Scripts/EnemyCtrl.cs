using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour {

	public int ePower;			//Power of the enemy
	public GameObject enemy;


	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Card")){
			GameCtrl.instance.CardContact (enemy);
		}
	}
}

