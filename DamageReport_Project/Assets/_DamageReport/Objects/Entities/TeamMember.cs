using UnityEngine;

public class TeamMember : MonoBehaviour
{
    public Team Team;

    public bool IsHostileTo(TeamMember other) => Team.IsHostileTo(other.Team);
}
