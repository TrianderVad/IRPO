using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.DeviceSimulation;
using UnityEngine;

public class Main : MonoBehaviour
{

    public GameObject plane;
    public Simulator simulator;

    void Start()
    {
        plane = GameObject.Find("Plane");
        this.simulator = plane.GetComponent<Simulator>();
        simulator.addNode("1", new Node("1"));
        simulator.addNode("2", new Node("2"));
        simulator.addNode("3", new Node("3"));

        simulator.addRoad("1", "2", 1000);
        simulator.addRoad("3", "2", 2000);
        simulator.addCar(new Car(0, 3, new String[] {"1", "2", "3"}));
    }   
}
