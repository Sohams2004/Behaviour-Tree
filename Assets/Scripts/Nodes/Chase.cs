using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : Node
{
    [SerializeField] float speed;
    [SerializeField] Transform enemy;
    [SerializeField] Transform player;

    public Chase(float speed, Transform enemy, Transform player)
    {
        this.speed = speed;
        this.enemy = enemy;
        this.player = player;
    }

    public override States RunState()
    {
        Debug.Log("Chased");

        if (Vector3.Distance(enemy.position, player.position) > 0.2f)
        {
            Vector3 direction = (player.position - enemy.position).normalized;
            enemy.position += direction * speed * Time.deltaTime;

            return States.Running;
        }

        else
        {
            return States.Success;
        }
    }
}
