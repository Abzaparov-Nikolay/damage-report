using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
	[SerializeField] private List<TextMeshProUGUI> texts;


	public void SetText(string value)
	{
		foreach (var text in texts)
		{
			text.text = value;
		}
	}

	public void SetText(float value)
	{
		foreach (var text in texts)
		{
			
			text.text = $"{((int)((value * 100) % 1000)).ToString()}%";
		}
	}
}
