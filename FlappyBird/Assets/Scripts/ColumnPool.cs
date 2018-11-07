using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

	public float spawnRate = 4f;
	public int columnPoolSize = 5;
	public GameObject columnPrefab;
	public float columnMin = -2f;
	public float columnMax = -0.5f;

	private float timeSinceLastSpawn;
	private Vector2 objectPoolPosition = new Vector2 (-15f, -25f);
	private GameObject[] columns;
	private float spawnXPos = 10f;
	private int id = 0;

	// Use this for initialization
	void Start () {
		columns = new GameObject[columnPoolSize];
		for (int i = 0; i < columnPoolSize; i++) {
			columns [i] = (GameObject)Instantiate (columnPrefab, objectPoolPosition, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastSpawn += Time.deltaTime;
		if (GameController.instance.gameOver == false && timeSinceLastSpawn >= spawnRate) {
			timeSinceLastSpawn = 0;
			float spawnYPos = Random.Range (columnMin, columnMax);
			columns [id].transform.position = new Vector2 (spawnXPos, spawnYPos);
			id++;
			if (id >= columnPoolSize)
				id = 0;
		}
	}
}
