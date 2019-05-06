using UnityEngine;

public class Spinner : MonoBehaviour {

    [SerializeField] private float speedOfSpin = 360f;  //360 degrees per second
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, speedOfSpin * Time.deltaTime);
	}
}
