using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Inverter : Node
{
    protected Node node;

    public Inverter(Node children)
    {
        this.node = children;
    }

    public override States RunState()
    {
        switch (node.RunState())
        {
            case States.Running:
                states = States.Running;
                break;

            case States.Success:
                states = States.Failed;
                break;

            case States.Failed:
                states = States.Success;
                break;

            default:
                break;
        }

        return states;
    }
}
