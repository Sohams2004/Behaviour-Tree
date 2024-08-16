using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNode : Node
{
    EnemyAI enemyAI;
    [SerializeField] float health;

    public HealthNode(EnemyAI enemyAi, float health)
    {
        this.enemyAI = enemyAi;
        this.health = health;
    }

    public override States RunState()
    {
        return enemyAI.GetCurrentHealth() <= health ? States.Success : States.Failed;
    }
}
