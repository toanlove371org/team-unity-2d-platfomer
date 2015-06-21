using UnityEngine;
using System.Collections;

public class DialogTooltip : MonoBehaviour {

	public string text = "";
	public float visibleTime = 1f;

	private SpriteRenderer spriteRenderer;
	private Animator animator;
	private Sprite sprite;
	private bool isTriggered;

	void Awake () {
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		sprite = spriteRenderer.sprite;
		spriteRenderer.sprite = null;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowToolTip(Vector2 pos, float time) {
		
		spriteRenderer.sprite = sprite;
		this.gameObject.transform.position = pos;
		visibleTime = time;
		StartCoroutine(show(time));
	}

	public void ShowToolTip( float time) {
		ShowToolTip(this.gameObject.transform.position, time);
	}

	public void ShowToolTip() {
		ShowToolTip (this.gameObject.transform.position, visibleTime);
	}

	IEnumerator show(float time) {
		yield return new WaitForSeconds(time);
//		spriteRenderer.sprite = null;
		Destroy(this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (!isTriggered) {
			if (col.tag == "Player") {
				ShowToolTip();
				GameTrigger.Instance.ShowNotice(text, visibleTime);
				isTriggered = true;
			}
		}
	}


}
