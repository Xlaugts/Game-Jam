using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCtrl : MonoBehaviour {


	public AudioList audioList;				// for accessing audio effects

	public static AudioCtrl instance;

	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
	}
	
	public void CardSpawnAudio(Vector3 pos){
		AudioSource.PlayClipAtPoint (audioList.card, pos);
	}

	public void ContactExplosionAudio(Vector3 pos){	
		AudioSource.PlayClipAtPoint (audioList.cardsContact, pos);
	}

	public void LifePickup(Vector3 pos){
		AudioSource.PlayClipAtPoint (audioList.life, pos);
	}

	public void SpecialEnableSound(Vector3 pos){
		AudioSource.PlayClipAtPoint (audioList.specialEnable, pos);
	}
}
