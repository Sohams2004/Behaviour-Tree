using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float enemyHealth;

    [SerializeField] float chasingRange;
    [SerializeField] float attackRange;

    [SerializeField] Transform player;
    [SerializeField] Transform enemy;

    [SerializeField] bool isInRange;

    [SerializeField] Material enemyMaterial;

    Node root;

    private void Awake()
    {
        //enemyMaterial = GetComponent<Material>();
    }

    private void Start()
    {
        root = BehaviourTree();
    }

    public float GetCurrentHealth()
    {
        return enemyHealth;
    }

    public void SetColor(Color color)
    {
        enemyMaterial.color = color;
    }

    private Node BehaviourTree()
    {
        HealthNode healthnode = new HealthNode(this, enemyHealth);
        Chase chase = new Chase(chasingRange, enemy, player);
        IsPlayerInRange chasingRng = new IsPlayerInRange(player, enemy, isInRange, chasingRange);
        IsPlayerInRange attackRng = new IsPlayerInRange(player, enemy, isInRange, attackRange);
        Attack _attack = new Attack(enemy, player, attackRange);

        Sequence chaseSequence = new Sequence(new List<Node> { chasingRng, chase });
        Sequence attackSequence = new Sequence(new List<Node> { attackRng, _attack });

        return new Selector(new List<Node>{attackSequence, chaseSequence});
    }

    private void Update()
    {
        root.RunState();
    }
}
