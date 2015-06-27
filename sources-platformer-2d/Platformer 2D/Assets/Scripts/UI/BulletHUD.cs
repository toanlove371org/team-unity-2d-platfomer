using UnityEngine;
using System.Collections;

public class BulletHUD : MonoBehaviour {

	private GUITexture guiIcon;
//	private GUIText guiTime;
	private GUITexture guiTimeBar;

	#region Singleton
	private static BulletHUD instance;
	private BulletHUD() {}
	public static BulletHUD Instance {
		get {
			if (instance == null) {
				instance = GameObject.FindObjectOfType(typeof(BulletHUD)) as  BulletHUD;
			}
			return instance;
		}
	}
	#endregion

	void Awake() {
		guiIcon = this.GetComponent<GUITexture>();
//		guiTime = this.GetComponent<GUIText>();
		guiTimeBar = this.transform.GetChild(0).GetComponent<GUITexture>();
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

	public void SetTime(float time) {
//		guiTime.text = time + "s";
//		if (time > 0) {
//			guiTime.enabled = true;
//		}
//		else {
//			guiTime.enabled = false;
//		}


		guiTimeBar.pixelInset = new Rect(100,
		                                 25,
		                                 200 * time / 60, // value
		                                 20);
	}
}
