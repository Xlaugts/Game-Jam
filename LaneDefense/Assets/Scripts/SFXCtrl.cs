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

	// Special enable effect
	public void SpecialEnableSFX(Vector3 pos){
		Instantiate (sfx.specialFX, pos, Quaternion.identity);
	}

	// Enemy explosion effect
	public void SFX_Explosion(Vector3 pos, int color){ // color 0 = green, 1 = red, 2 = yellow
		Instantiate(sfx.sfx_Eplosion[color], pos,Quaternion.identity);
	}

}
