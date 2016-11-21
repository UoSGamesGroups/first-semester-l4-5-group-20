using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float gameRound = 1;
	public bool roundFinished = false;
	public float currentEnemies = 0;
	public float enemiesToSpawn = 5;
	public float spawnTimer = 2f;

	private float sT = 2f;

	void Update() {
		if (currentEnemies != enemiesToSpawn && !roundFinished) {
			spawnTimer = spawnTimer - 1 * Time.deltaTime;
			if (spawnTimer <= 0) {
				SpawnEnemy();
				spawnTimer = sT;
			}
		} else if (currentEnemies == enemiesToSpawn) {
			roundFinished = true;
			StartCoroutine(Temp());
		}
	}

	void SpawnEnemy() {
			Instantiate(enemyPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
			currentEnemies++;
	}

	IEnumerator Temp()
	{
		gameRound++;
		enemiesToSpawn = enemiesToSpawn * 2;
		yield return new WaitForSeconds(5);
		roundFinished = false;
	}

}
