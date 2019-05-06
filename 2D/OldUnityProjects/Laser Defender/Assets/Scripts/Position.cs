using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

	//Sirve para ver la posicion de los objetos en la pantalla de diseño
	void OnDrawGizmos() {
		Gizmos.DrawWireSphere (transform.position, 1);
	}
}
