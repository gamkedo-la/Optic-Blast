using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour {
	public List<GameObject> spawnedEnemies = new List<GameObject>();
	public GameObject enemyToSpawn;
    public float spawnFrequency = 3.0f;
    public int spawnCap = 3;
	public float minSpawnDist = 35.0f;
	public float maxSpawnDist = 45.0f;
	float minHeight = 20.0f;
	public bool spawnEyeLevelOnly = false;

	void SpawnEnemy() {
		Vector3 spawnVect = Random.onUnitSphere * Random.Range(minSpawnDist,maxSpawnDist);
		if(spawnVect.y < 0.0f) {
			spawnVect.y = -spawnVect.y;
		}
		if(spawnEyeLevelOnly) {
			spawnVect.y = transform.position.y;
			minHeight = 1.0f;
		}
		spawnedEnemies.Add( (GameObject) GameObject.Instantiate(enemyToSpawn, transform.position + spawnVect + Vector3.up * minHeight, Quaternion.identity) );
	}

	void ReapDead() {
		spawnedEnemies.RemoveAll(item => item == null);
	}

	IEnumerator RespawnEnemies() {
		while(true) {
			yield return new WaitForSeconds(spawnFrequency);
			ReapDead();
			if(spawnedEnemies.Count < spawnCap) {
				SpawnEnemy();
			}
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(RespawnEnemies());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
