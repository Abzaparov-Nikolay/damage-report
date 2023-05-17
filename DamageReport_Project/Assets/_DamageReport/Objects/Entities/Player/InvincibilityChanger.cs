using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvincibilityChanger : MonoBehaviour
{
    public Reference<bool> InvinsibilityState;
    public Reference<float> InvincibilityDuration;
	public UnityEvent OnInvincibilityStart;

	public void StartInvisibilityState()
	{
		InvinsibilityState.Set(true);
		OnInvincibilityStart?.Invoke();
		StartCoroutine(GoVulnerable());
	}

	private IEnumerator GoVulnerable()
	{
		yield return new WaitForSeconds(InvincibilityDuration.Value);
		InvinsibilityState.Set(false);
	}
}
