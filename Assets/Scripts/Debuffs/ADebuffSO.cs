using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ADebuffSO : ScriptableObject 
{
    public abstract void Debuff(Enemy enemy);
}
