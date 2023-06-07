using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UpgradeData
{
    public string guid;
    public int level;

    public UpgradeData(Upgrade upgrade)
    {
        this.guid = upgrade.UID;
        this.level = upgrade.bonus.level;
    }
}
