using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Enemy spawner.
/// Spanw the enemies in randomly lanes.
/// </summary>
public class EnemySpawner : MonoBehaviour {


	public float spawnDelay;				// Delay between each spawn set this to 2.5
	public EnemyTypes enemies;				// Get the Class EnemyType which stores all enemies
	[Header("Enemy Position Spawn")]
	public Transform pos1;                  // Get's the gameobjects that holds the positions where the enemies are going to spawn
	public Transform pos2;
	public Transform pos3;
	public Transform pos4;

	bool canSpawn;							// allow an enemy to be spwned
	List<Transform> EnemyPosSpawn = new List <Transform> ();			// list with all positions the enemies are going to be spawned

	void Awake(){
		// Positions where the enemies are going to be spawned
		EnemyPosSpawn.Add (pos1);
		EnemyPosSpawn.Add (pos2);
		EnemyPosSpawn.Add (pos3);
		EnemyPosSpawn.Add (pos4);
	


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


	/// <summary>
	/// Spawns a random enemy after a delay
	/// </summary>
	/// <returns>The enemy.</returns>
	IEnumerator SpawnEnemy(){
		int r = Random.Range (0, 4);		// gets the random position to spawn
		int e = Random.Range (0, 3);		// set the random enemy to spanw
		int liveR = Random.Range (0, 20); // chance for a life to spawn 1 in 15
		Transform allPos = EnemyPosSpawn [r];
		Vector3 vec = allPos.transform.position;

		if (liveR == 4) {
			Instantiate (enemies.enemies [3], vec, Quaternion.identity);
		} else {
			if (e == 0) {
				Instantiate (enemies.enemies [e], vec, Quaternion.identity);
			} else if (e == 1) {
				Instantiate (enemies.enemies [e], vec, Quaternion.identity);
			} else if (e == 2) {
				Instantiate (enemies.enemies [e], vec, Quaternion.identity);
			}
		}

		canSpawn = false;
		yield return new WaitForSeconds (spawnDelay);
		canSpawn = true;
	}


}
