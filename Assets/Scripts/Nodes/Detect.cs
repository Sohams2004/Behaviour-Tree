using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : Node
{
    RaycastHit hit;
    [SerializeField] Transform enemy;
    [SerializeField] Transform player;

    public Detect(Transform enemy, Transform player)
    {
        this.enemy = enemy;
        this.player = player;
    }

    public override States RunState()
    {
        bool isRay = Physics.Raycast(enemy.position, enemy.position - player.position, out hit);

        if (isRay)
        {
            if(hit.collider.transform != player)
            {
                return States.Success;
            }
        }
        return States.Failed;
    }
}
