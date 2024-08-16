using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Node
{
    EnemyAI enemyAI;
    
    [SerializeField] Transform enemy;
    [SerializeField] Transform player;

    [SerializeField] float attackRange; 

    public Attack(Transform enemy, Transform player, float attackRange)
    {
        this.enemy = enemy;
        this.player = player;
        this.attackRange = attackRange;
    }


    public override States RunState()
    {
        Debug.Log("Attacked");

        float distance = Vector3.Distance(enemy.position, player.position);
        if (distance <= attackRange)
        {
            Debug.Log("in attack range");

            //enemyAI.SetColor(Color.red);
            return States.Running;
        }

        else
        {
            return States.Failed;
        }
    }
}
