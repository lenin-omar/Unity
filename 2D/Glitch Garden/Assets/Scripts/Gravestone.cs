using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour {

    private void OnTriggerStay(Collider otherCollider) {
        Attacker attacker = otherCollider.GetComponent<Attacker>();
        if (attacker) {
            //TODO: Do some animation
        }
    }
}
