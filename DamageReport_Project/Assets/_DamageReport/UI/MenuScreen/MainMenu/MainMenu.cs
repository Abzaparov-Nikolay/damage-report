using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioChanger changer;

	private void Start()
	{
		if(changer != null)
		{
			changer.LoadAudioSettings();
		}
	}
}
