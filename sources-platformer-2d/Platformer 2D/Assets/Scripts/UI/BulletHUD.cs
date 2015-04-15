using UnityEngine;
using System.Collections;

public class BulletHUD : MonoBehaviour {

	private GUITexture guiIcon;

	void Awake() {
		guiIcon = this.GetComponent<GUITexture>();
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
}
