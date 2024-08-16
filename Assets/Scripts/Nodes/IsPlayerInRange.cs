using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class IsPlayerInRange : Node
{
    [SerializeField] Transform player;
    [SerializeField] Transform enemy;
    [SerializeField] float range;
    [SerializeField] bool isPlayerInRange;


    public IsPlayerInRange(Transform player, Transform enemy, bool isPlayerInRange, float range)
    {
        this.player = player;
        this.enemy = enemy;
        this.isPlayerInRange = isPlayerInRange;
        this.range = range;
    }

    public override States RunState()
    {
        Debug.Log("In range");

        float distance = Vector3.Distance(enemy.position, player.position);
        //Debug.Log(distance);

        if (distance <= range)
        {
            isPlayerInRange = true;
            return States.Success;
        }

        else
        {
            isPlayerInRange= false;
            return States.Failed;
        }
    }
}
