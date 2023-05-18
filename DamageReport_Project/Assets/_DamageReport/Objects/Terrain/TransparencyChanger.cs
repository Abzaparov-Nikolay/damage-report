using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyChanger : MonoBehaviour
{
	[Range(0f, 1f)]
	public float threshhold = 0.7f;
	public float fadeSpeed = 3;
	private float startAlpha = 1;

	private void Update()
	{
		
	}

	public void BecomeTransparent()
	{
		var renderer = gameObject.GetComponent<Renderer>();
		var startColor = renderer.material.color;
		//startAlpha = startColor.a;
		renderer.material.color = new Color(startColor.r, startColor.g, startColor.b,
			Mathf.Lerp(startColor.a, threshhold, fadeSpeed));
		StopCoroutine(ResetTransperancy());
		StartCoroutine(ResetTransperancy());
	}

	private IEnumerator ResetTransperancy()
	{
		yield return new WaitForSeconds(3);
		var renderer = gameObject.GetComponent<Renderer>();
		var col = renderer.material.color;
		renderer.material.color = new Color(col.r,col.g,col.b,startAlpha);
	}
}
