using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour {

    [SerializeField] Text textComponent;    //[SerializeField] makes textComponent available in Unity inspector
    [SerializeField] State startingState;    //[SerializeField] makes startingState available in Unity inspector

    State currentState;

	// Use this for initialization
	void Start () {
        currentState = startingState;
        textComponent.text = currentState.GetStateStory();
	}
	
	// Update is called once per frame
	void Update () {
        ManageState();
	}

    private void ManageState() {
        var nextStates = currentState.GetNextStates();
        for (int i = 0; i < nextStates.Length; i++) {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)) {
                currentState = nextStates[i];
                textComponent.text = currentState.GetStateStory();
            }
        }
    }
}
