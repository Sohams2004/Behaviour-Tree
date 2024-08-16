using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    public List<Node> children = new List<Node>();

    public bool isChildRunning;

    public Sequence(List<Node> children)
    {
        this.children = children;
    }

    public override States RunState()
    {
        foreach (Node node in children)
        {
            switch(node.RunState()) 
            { 
                case States.Running:
                    isChildRunning = true;
                    break;

                case States.Success:
                    break;

                case States.Failed:
                    states = States.Failed;
                    return States.Failed;   

                default: 
                    break;
            }
        }

        states = isChildRunning ? States.Running : States.Success;
        return states;
    }
}
