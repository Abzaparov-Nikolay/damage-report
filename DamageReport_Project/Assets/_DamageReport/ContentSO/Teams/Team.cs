using UnityEngine;

[CreateAssetMenu(menuName = MenuNames.Content + nameof(Team))]
public class Team : ScriptableObject
{
    public bool IsHostileTo(Team other) => this != other;
}
