using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Card select ctrl.
/// Instantiate a card when clicks on it
/// </summary>
public class CardSelectCtrl : MonoBehaviour {

	public void Card(GameObject card){
		Instantiate (card);
	}

}
