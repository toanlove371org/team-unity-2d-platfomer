using UnityEngine;
using System.Collections;

public class TrigCheckDestroyExtend : TrigCheckDestroyed {

	protected override void Action () {
		StartCoroutine(WaitToShowText());
	}

	IEnumerator WaitToShowText() {
		GameTrigger.Instance.ShowNotice("Congratulation!",5f);
		yield return new WaitForSeconds(5);
		FadeScene.LoadLevel("StartScreen", 1f, 1f, Color.white);
	}
}
