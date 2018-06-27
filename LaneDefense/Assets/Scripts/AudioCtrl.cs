using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Audio fx for the game
/// </summary>
public class AudioCtrl : MonoBehaviour {


	public AudioList audioList;				// for accessing audio effects

	public static AudioCtrl instance;

	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
	}

	//Cards select audio
	public void CardSpawnAudio(Vector3 pos){
		AudioSource.PlayClipAtPoint (audioList.card, pos);
	}

	// Enemy explosion audio
	public void ContactExplosionAudio(Vector3 pos){	
		AudioSource.PlayClipAtPoint (audioList.cardsContact, pos);
	}

	// Life pickup audio
	public void LifePickup(Vector3 pos){
		AudioSource.PlayClipAtPoint (audioList.life, pos);
	}

	// Special enamble audio
	public void SpecialEnableSound(Vector3 pos){
		AudioSource.PlayClipAtPoint (audioList.specialEnable, pos);
	}
}
