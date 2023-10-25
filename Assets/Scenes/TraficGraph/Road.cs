using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Road
{
    public List<Car> cars = new List<Car>(); // Список всех машин на дороге
    public List<Car> carsForDelete = new List<Car>(); // Список машин, которые надо удалить с дороги
    public Node node1;
    public Node node2;
    public long roadSize;

    public bool drive = false;

    GameObject attached;

    private void Start()
    {
        //attached = gameObject;
    }

    public Road(Node node1, Node node2, long roadSize)
    {
        this.node1 = node1;
        this.node2 = node2;
        this.roadSize = roadSize;
    }

    public void addCars(List<Car> newCars)
    {
        foreach (Car car in newCars)
        {
            if (this.cars.Count == 0)
            {
                cars.Add(car);
                car.changeTime(Simulator.gameTime);
            }
            else
            {
                car.changeDistance(cars.Last().getX());
                car.changeTime(Simulator.gameTime);
                cars.Add(car);
            }
        }
    }

    public void addCar(Car car)
    {
        if (cars.Count == 0)
        {
            cars.Add(car);
            car.changeTime(Simulator.gameTime);
        }
        else
        {
            car.changeDistance(cars.Last().getX());
            car.changeTime(Simulator.gameTime);
            cars.Add(car);
        }
        Debug.Log("Добавлена машина: " + car);
        Debug.Log("Количество машин: " + cars.Count);
    }

    public void printTime()
    {
        Debug.Log(Simulator.gameTime);
    }

    public void moveCars()
    {
        if (cars.Count == 0)
        {
            return;
        }
        Car firstCar = cars.First();

        if (firstCar.getX() == roadSize)
        {
            carsForDelete.Add(firstCar);
            cars.Remove(firstCar);
            if (cars.Count == 0)
            {
                return;
            }
            firstCar = cars.First();
        }

        firstCar.changeCoordinate();

        if (firstCar.getX() > roadSize) { firstCar.changeCoordinate(roadSize); }

        for (int i = 1; i < cars.Count; i++)
        {
            Car secondCar = cars[i];
            if (secondCar.getX() + 40 > firstCar.getX())
            {
                secondCar.changeSpeed(firstCar.getSpeed());
            }
            long xForNewCar = firstCar.getX() - secondCar.getDistanceToNextCar() +
                    (Math.Abs(firstCar.getSpeed() - secondCar.getSpeed())) * (Simulator.gameTime - secondCar.getTimeEnterRoad());
            cars[i].changeCoordinate(xForNewCar);

            firstCar = secondCar;
        }

        printCoordinateCars();
    }

    public List<Car> getCarsForDelete()
    {
        return carsForDelete;
    }

    public bool hasCars()
    {
        return cars.Count > 0;

    }

    public void printCoordinateCars()
    {
        foreach (Car car in cars)
        {
            Debug.Log("Координата машины (ее скорость): " + car.getX() + " (" + car.getSpeed() + ") ");
        }
    }

}
