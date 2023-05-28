using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = MenuNames.Manager + "Scene")]
public class SceneLoader : ScriptableObject
{
    public void Load(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
