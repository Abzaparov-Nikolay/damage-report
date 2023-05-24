using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyChanger : MonoBehaviour
{
	[Range(0f, 1f)]
	public float threshhold = 0.7f;
	public float fadeInterval = 2;
	public float resetInterval = 2;
	private float startAlpha = 1;
	private IEnumerator resetter;
	private IEnumerator fader;
	private int stepsCount = 15;

	private int calls;
	private int lastUpdateCalls;

	private void Update()
	{
		if (calls > 0)
		{
			if (lastUpdateCalls == 0)
			{
				BecomeTransperent();
				lastUpdateCalls = calls;
			}
		}
		else
		{
			if (lastUpdateCalls > 0)
			{
				BecomeVisible();
				lastUpdateCalls = 0;
			}
		}
		calls = 0;
	}

	public void Call()
	{
		calls++;
	}

	public void BecomeTransperent()
	{
		Fade();
		calls = 1;	
		lastUpdateCalls = 1;
		if (resetter != null)
		{
			StopCoroutine(resetter);
			resetter = null;
		}
	}

	public void BecomeVisible()
	{
		if (fader != null)
		{
			StopCoroutine(fader);
			calls = 0;
			lastUpdateCalls = 0;
			fader = null;
		}
		if (resetter != null)
		{
			StopCoroutine(resetter);
		}
		resetter = ResetTransperancy();
		StartCoroutine(resetter);
	}

	private IEnumerator ResetTransperancy()
	{
		var renderer = gameObject.GetComponent<Renderer>();
		var col = renderer.material.color;
		for (float i = 1; i <= stepsCount; i++)
		{
			renderer.material.color = new Color(col.r, col.g, col.b, Mathf.Lerp(col.a, startAlpha, i / stepsCount));
			yield return new WaitForSeconds(resetInterval / stepsCount);
		}
		resetter = null;
	}

	private void Fade()
	{
		if (fader != null)
		{
			return;
		}
		fader = FadeSlowly();
		StartCoroutine(fader);
	}

	private IEnumerator FadeSlowly()
	{
		var renderer = gameObject.GetComponent<Renderer>();
		var startColor = renderer.material.color;
		for (float i = 1; i <= stepsCount; i++)
		{
			renderer.material.color = new Color(startColor.r, startColor.g, startColor.b,
			Mathf.Lerp(startColor.a, threshhold, i / stepsCount));
			yield return new WaitForSeconds(fadeInterval / stepsCount);
		}
		fader = null;
	}
}
