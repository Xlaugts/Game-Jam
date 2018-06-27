using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Load scene.
/// </summary>
public class LoadScene : MonoBehaviour {

	public string scene;

	public void ReloadScene(){
		SceneManager.LoadScene ("01");
	}

	public void SceneLoad(){
		SceneManager.LoadScene (scene);
	}
		
	public void Play(){
		GameCtrl.instance.ClickUnpause ();
	}

	public void Pause(){
		GameCtrl.instance.ClickPause ();
	}
}
