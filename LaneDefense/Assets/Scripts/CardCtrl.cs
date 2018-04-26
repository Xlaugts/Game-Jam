using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controls the cards behaviour 
/// </summary>
public class CardCtrl : MonoBehaviour {

	public float moveSpeed;			// Speed that the card follows the mouse
	public int cPower;				// Define power of the card

	private Vector3 mousePos;		// Get's the mouse position

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		FollowMouse ();
	}

	/// <summary>
	/// Makes the card follows the mouse and 
	/// destroy it if the left click is released
	/// </summary>
	void FollowMouse(){
			mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint (mousePos);
			transform.position = Vector2.Lerp (transform.position, mousePos, moveSpeed);
		 if (Input.GetMouseButtonUp (0)) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Enemy")|| other.gameObject.CompareTag("Lives")){
			
			Destroy(gameObject);
		}
	}
}
