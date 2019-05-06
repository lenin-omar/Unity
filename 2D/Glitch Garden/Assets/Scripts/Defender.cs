using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    [SerializeField] int starCost = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddStars(int amount) {
        FindObjectOfType<StarsDisplay>().AddStars(amount);
    }

    public int GetStarCost() {
        return starCost;
    }

}
