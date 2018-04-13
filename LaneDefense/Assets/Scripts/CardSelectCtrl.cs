using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Card select ctrl.
/// Instantiate a card when clicks on it
/// </summary>
public class CardSelectCtrl : MonoBehaviour {

	public GameObject button;				// Get's the button gameobject


	/// <summary>
	/// Card the specified card.
	/// Instatntiate the card to the Button position
	/// </summary>
	/// <param name="card">Card.</param>
	public void Card(GameObject card){
		Instantiate (card, button.transform.position, Quaternion.identity);
	
	}

}
