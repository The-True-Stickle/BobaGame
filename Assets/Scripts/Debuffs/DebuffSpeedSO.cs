using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DebuffSO/SpeedDebuf")]
public class DebuffSpeedSO : ADebuffSO
{
    public float amount;
    public override void Debuff(Enemy enemy)
    {
        enemy.DecreaseMoveSpeed(amount);
	}
}
