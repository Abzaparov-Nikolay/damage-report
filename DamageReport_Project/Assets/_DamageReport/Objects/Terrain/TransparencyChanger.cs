using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyChanger : MonoBehaviour
{
	[Range(0f, 1f)]
	public float threshhold = 0.7f;
	public float fadeSpeed = 3;
	private float startAlpha = 1;
	private IEnumerator resetter;

	public void BecomeTransparentWithReset()
	{
		Fade();
		if(resetter != null )
		{
			StopCoroutine(resetter);
		}
		resetter = ResetTransperancy();
		StartCoroutine(resetter);
	}

	public void BecomeTransperent()
	{
		Fade();
		if (resetter != null)
		{
			StopCoroutine(resetter);
		}
	}

	public void BecomeVisible()
	{
		if (resetter != null)
		{
			StopCoroutine(resetter);
		}
		resetter = ResetTransperancy();
		StartCoroutine(resetter);
	}

	private IEnumerator ResetTransperancy()
	{
		yield return new WaitForSeconds(fadeSpeed);
		var renderer = gameObject.GetComponent<Renderer>();
		var col = renderer.material.color;
		renderer.material.color = new Color(col.r,col.g,col.b,startAlpha);
	}

	private void Fade()
	{
		var renderer = gameObject.GetComponent<Renderer>();
		var startColor = renderer.material.color;
		renderer.material.color = new Color(startColor.r, startColor.g, startColor.b,
			Mathf.Lerp(startColor.a, threshhold, fadeSpeed));
	}
}
