using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInstructions : MonoBehaviour {

	public GameObject instructions;

	void Start(){
		instructions.SetActive (false);
	}

	public void ActiveInstruct(){
		instructions.SetActive (true);
	}
}
