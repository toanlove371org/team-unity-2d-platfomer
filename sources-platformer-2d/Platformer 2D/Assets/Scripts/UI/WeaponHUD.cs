using UnityEngine;
using System.Collections;

public class WeaponHUD : MonoBehaviour {

	private GUITexture guiIcon;
	private GUIText guiNumber;

	void Awake () {
		guiIcon = this.GetComponent<GUITexture>();
		guiNumber = this.GetComponent<GUIText>();

		guiIcon.enabled = false;
		guiNumber.enabled = false;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetIcon(Texture icon) {
		guiIcon.texture = icon;
	}

	public void SetNumber(int numb) {
		guiNumber.text = "x" + numb;

		if (numb > 0) {
			guiIcon.enabled = true;
			guiNumber.enabled = true;
		} else {
			guiIcon.enabled = false;
			guiNumber.enabled = false;
		}
	}
}
