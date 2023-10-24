using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private String name;
    Dictionary<Node, Road> roadsToNodes = new Dictionary<Node, Road>();

    public Node(String name)
    {
        this.name = name;
    }

    public void addRoad(Road road, Node node)
    {
        roadsToNodes.Add(node, road);
    }

    public String getName()
    {
        return this.name;
    }
    public void printRoadsToNodes()
    {
        Debug.Log("Node " + name + ": " + roadsToNodes.ToString());
    }

    public Road getRoadToNode(Node node)
    {
        return roadsToNodes[node] as Road;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
