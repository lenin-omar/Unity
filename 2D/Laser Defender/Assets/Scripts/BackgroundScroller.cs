using UnityEngine;

/*
 * This class is attached to a Quad
 */
public class BackgroundScroller : MonoBehaviour {

    //Configuration parameters
    [SerializeField] private float scrollSpeed = .2f;

    Material material;  //The background image
    Vector2 offset; //To scroll on X and/or Y axis

    // Use this for initialization
    void Start () {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(0, scrollSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        //Change the offset of the material in order to scroll
        material.mainTextureOffset += offset * Time.deltaTime;  //Frame rate independent
	}
}
