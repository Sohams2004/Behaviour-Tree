using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum States {Running, Success, Failed}

public abstract class Node
{
    protected States states;

    public abstract States RunState();
}
