using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DebuffSO/KillDebuf")]
public class DebuffKillSO : ADebuffSO
{
    public override void Debuff(Enemy enemy)
    {
        enemy.Die();
        Debug.Log("Kill Enemy!");
	}
}
