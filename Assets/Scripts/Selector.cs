using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Selector : Node
{
    public List<Node> children = new List<Node>();

    public Selector(List<Node> children)
    {
        this.children = children;
    }

    public override States RunState()
    {
        foreach (Node node in children)
        {
            switch (node.RunState())
            {
                case States.Running:
                    states = States.Running;
                    return States.Running;

                case States.Success:
                    states = States.Success;
                    return States.Success;

                case States.Failed:
                    break;

                default:
                    break;
            }
        }
        states = States.Failed;
        return states;
    }
}
