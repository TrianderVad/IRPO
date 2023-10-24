using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator : MonoBehaviour
{
    public static long gameTime = 0;
    public List<Road> roadsForRide = new List<Road>();
    public Dictionary<String, Node> allNodes = new Dictionary<string, Node>();
    public int speedSimulationRatio = 500;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameTime += 1;
        Debug.Log("Игровое время: " + gameTime);
        if (roadsForRide.Count > 0)
        {
            updateCoords();
        }
             
    }

    public void addCar(Car car)
    {
        Road road = allNodes[car.getPath()[car.getCurrent()]].getRoadToNode(allNodes[car.getPath()[car.getCurrent() + 1]]);
        road.addCar(car);
        roadsForRide.Add(road);
        car.changeTime(gameTime);
        car.changeCoordinate(0);
        Debug.Log("Добавлена машина " + car + " к дороге " + road);
        Debug.Log("Число дорог для движения " + roadsForRide.Count);
    }

    public void updateCoords()
    {
        List<Road> roadForDelete = new List<Road>();
        List<Car> carsForDelete = new List<Car>();
        foreach (Road road in roadsForRide)
        {
            if (road.hasCars())
            {
                road.moveCars();
                carsForDelete = road.getCarsForDelete();
            }
            else
            {
                roadForDelete.Add(road);
            }
        }
        if (roadForDelete.Count > 0)
        {
            foreach (Road road in roadForDelete) roadsForRide.Remove(road);
        }
        if (carsForDelete.Count > 0)
        {
            foreach (Car car in carsForDelete)
            {
                car.nextNode();
                if (car.getCurrent() < car.getPath().Length - 1)
                {
                    addCar(car);
                }
            }
        }
    }

    public void addNode(String name, Node node)
    {
        allNodes.Add(name, node);
    }

    public void addRoad(String nodeFrom, String nodeTo, long sizeRoad)
    {
        Road road = new Road(getNode(nodeFrom), getNode(nodeTo), sizeRoad);
        getNode(nodeFrom).addRoad(road, getNode(nodeTo));
        getNode(nodeTo).addRoad(road, getNode(nodeFrom));
    }

    public Node getNode(String name)
    {
        return allNodes[name];
    }

    public void printAllNodes()
    {
        Debug.Log("Список Nodes: " + allNodes.ToString());
    }

}
