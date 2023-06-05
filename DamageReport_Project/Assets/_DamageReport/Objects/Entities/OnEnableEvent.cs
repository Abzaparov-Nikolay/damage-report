using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableEvent : MonoBehaviour
{
    [SerializeField] UnityEvent onEnable;
    [SerializeField] UnityEvent onDisable;

	private void OnEnable()
	{
		onEnable?.Invoke();
	}

	private void OnDisable()
	{
		onDisable?.Invoke();
	}
}
