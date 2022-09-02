using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target : BattleEntity
{

    public abstract void GetHit(Projectile projectile);

}
