using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Enemy spawner.
/// Spanw the enemies in randomly lanes.
/// </summary>
public class EnemySpawner : MonoBehaviour {


	public float spawnDelay;				// Delay between each spawn
	public EnemyTypes enemies;				// Get the Class EnemyType which stores all enemies
	[Header("Enemy Position Spawn")]
	public Transform pos1;                  // Get's the gameobjects that holds the positions where the enemies are going to spawn
	public Transform pos2;
	public Transform pos3;
	public Transform pos4;


	bool canSpawn;
	List<Transform> EnemyPosSpawn = new List <Transform> ();

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


	IEnumerator SpawnEnemy(){
		int r = Random.Range (0, 4);
		int e = Random.Range (0, 3);
		Transform allPos = EnemyPosSpawn [r];
		Vector3 vec = allPos.transform.position;
		Instantiate (enemies.enemies [e],  vec,Quaternion.identity);
		canSpawn = false;
		yield return new WaitForSeconds (spawnDelay);
		canSpawn = true;
	}
}
