using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCtrl : MonoBehaviour {

	public SFX sfx;			

	public static SFXCtrl instance;


	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
	}
	
	public void CardsExplosion(Vector3 pos){
		Instantiate (sfx.contactExplosion, pos, Quaternion.identity);
	}

	public void SpecialEnableSFX(Vector3 pos){
		Instantiate (sfx.specialFX, pos, Quaternion.identity);
	}

}
