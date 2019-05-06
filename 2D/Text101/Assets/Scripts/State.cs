using UnityEngine;

//[CreateAssetMenu(menuName = "State")] makes able to right click
//and create a State scriptable object in assets Unity section
[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject {

    //[SerializeField] makes storyText available in Unity inspector
    //[TextArea(10,14)] determines the text area for storyText 
    [TextArea(10,14)][SerializeField] string storyText;

    //Each State wil keep track of their next States
    [SerializeField] State[] nextStates;

    public string GetStateStory() {
        return storyText;
    }

    public State[] GetNextStates() {
        return nextStates;
    }
}
