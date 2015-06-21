using UnityEngine;
using System.Collections;

public class BulletHUD : MonoBehaviour {

	private GUITexture guiIcon;
	private GUIText guiTime;

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
		guiTime = this.GetComponent<GUIText>();
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

	public void SetTime(int time) {
		guiTime.text = time + "s";
		if (time > 0) {
			guiTime.enabled = true;
		}
		else {
			guiTime.enabled = false;
		}
	}
}
