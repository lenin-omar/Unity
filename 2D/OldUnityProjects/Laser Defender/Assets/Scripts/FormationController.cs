using UnityEngine;
using System.Collections;

public class FormationController : MonoBehaviour {

	public GameObject enemyPrefab;	//prefab de la nave enemiga, ya qye es publica se asigna en el inspector.
	public float width = 16f;
	public float height = 12f;
	public float speed = 5f;
	public float spawnDelay = 0.5f;

	private bool movingRight = true;
	private float xmin;
	private float xmax;

	// Use this for initialization
	void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint (new Vector3(0,0,distanceToCamera));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint (new Vector3(1,0,distanceToCamera));
		xmin = leftBoundary.x;
		xmax = rightBoundary.x;
		//SpawnEnemies ();
		SpawnUntilFull ();
	}

	void SpawnUntilFull() {
		Transform newEnemyTransform = NextFreePosition ();
		if (newEnemyTransform) {
			//Quaternion.identity es la rotacion del objeto. "as GameObject" es el casteo.
			GameObject enemy = Instantiate (enemyPrefab, newEnemyTransform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = newEnemyTransform;	//se obliga a que el nuevo gameobject enemy sea hijo del objeto newEnemyTransform
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}

	/*void SpawnEnemies() {
		foreach (Transform child in transform ) {	//transform pertenece a EnemyFormation. Cada child es un position.
			//Quaternion.identity es la rotacion del objeto. "as GameObject" es el casteo.
			GameObject enemy = Instantiate (enemyPrefab, child.position, Quaternion.identity) as GameObject;
			//enemy.transform.parent = transform;	//se obliga a que el nuevo gameobject enemy sea hijo del objeto EnemyFormation.
			enemy.transform.parent = child;	//se obliga a que el nuevo gameobject enemy sea hijo del objeto child/position
		}
	}*/

	//Sirve para ver la posicion de los objetos en la pantalla de diseño
	void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3(width, height, 0));
	}
	
	// Update is called once per frame
	void Update () {
		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);
		if (rightEdgeOfFormation >= xmax) {
			movingRight = false;
		} else if (leftEdgeOfFormation <= xmin) {
			movingRight = true;
		}
		if (AllMemberDead()) {
			//Debug.Log("Empty formation");
			//SpawnEnemies();
			SpawnUntilFull();
		}
	}

	bool AllMemberDead() {
		foreach(Transform childPositionGameObject in transform){
			if (childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}

	Transform NextFreePosition() {
		foreach(Transform childPositionGameObject in transform){
			if (childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			}
		}
		return null;
	}
}
