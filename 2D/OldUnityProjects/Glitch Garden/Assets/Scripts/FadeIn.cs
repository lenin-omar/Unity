using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public float fadeInTime;

	private Image fadePanel;
	private Color currentColor = Color.black;


	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTime) {
			//Fade in
			float alphaChange = Time.deltaTime / fadeInTime;	//Time.deltaTime es aprox 50 ms
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;
		} else {
			gameObject.SetActive (false);	//Se desactiva el gameObject (que en este caso es un Panel) para que se pueda dar click a los botones
		}
	}
}
