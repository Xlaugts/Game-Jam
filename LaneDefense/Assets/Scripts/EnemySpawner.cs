using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Enemy spawner.
/// Spanw the enemies in randomly lanes.
/// </summary>
public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;				// Get's the enemy object
	public float spawnDelay;				// Delay between each spawn


	bool canSpawn;
	List<Vector3> EnemyPosSpawn = new List <Vector3> ();

	void Awake(){
		// Positions where the enemies are going to be spawned
		EnemyPosSpawn.Add (new Vector3 (-2.9f, 4.6f, 0f));
		EnemyPosSpawn.Add (new Vector3 (-1.55f, 4.6f, 0f));
		EnemyPosSpawn.Add (new Vector3 (-0.1f, 4.6f, 0f));
		EnemyPosSpawn.Add (new Vector3 (1.35f, 4.6f, 0f));
		EnemyPosSpawn.Add (new Vector3 (2.8f, 4.6f, 0f));


	}

	// Use this for initialization
	void Start () {
		
		canSpawn = true;

	}

	// Update is called once per frame
	void Update () {
		
		if (canSpawn) {
			StartCoroutine("SpawnEnemy");
		}
	}


	IEnumerator SpawnEnemy(){
		int r = Random.Range (0, 5);
		Instantiate (enemy,  EnemyPosSpawn [r], Quaternion.identity);
		canSpawn = false;
		yield return new WaitForSeconds (spawnDelay);
		canSpawn = true;
	}
}
