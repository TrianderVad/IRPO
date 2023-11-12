using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Road
{
    public List<Car> cars = new List<Car>(); // Список всех машин на дороге
    public List<Car> carsForDelete = new List<Car>(); // Список машин, которые надо удалить с дороги
    public float minDistance = 2;  // Минимальная дистанция между машинами

    // Узлы, которые соединяет дорога
    public Node node1;
    public Node node2;
    public long roadSize;  // Длина дороги


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
                car.changeDistanceToNextCar(cars.Last().getX());
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
            car.changeTime(Simulator.gameTime); // Устанавливаем время въезда на дорогу
        }
        else
        {
            car.changeDistanceToNextCar(cars.Last().getX());
            car.changeTime(Simulator.gameTime);
            cars.Add(car);
        }
  //      Debug.Log("Добавлена машина: " + car);
  //      Debug.Log("Количество машин: " + cars.Count);
    }

    public void moveCars()
    {
        if (cars.Count == 0)
        {
            return;
        }

        Car firstCar = cars.First();

        // Если первая машина достигла конца дороги, то убираем ее и переназначаем firstCar
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

        float xForNewCar;
        for (int i = 1; i < cars.Count; i++)
        {
            Car currentCar = cars[i];
            if (currentCar.getX() + minDistance > firstCar.getX())
            {
                currentCar.changeSpeed(firstCar.getSpeed());
            }

            if (currentCar.getSpeed() == firstCar.getSpeed())
            {
                xForNewCar = firstCar.getX() - currentCar.getDistanceToNextCar();
            }
            else
            {
                //xForNewCar = firstCar.getX() - currentCar.getDistanceToNextCar() +
                //      (Math.Abs(firstCar.getSpeed() - currentCar.getSpeed())) * (Simulator.gameTime - currentCar.getTimeEnterRoad());

                xForNewCar = currentCar.getSpeed() * (Simulator.gameTime - currentCar.getTimeEnterRoad());
            }

            currentCar.changeCoordinate(xForNewCar);
            currentCar.changeDistanceToNextCar(firstCar.getX() - currentCar.getX());


            firstCar = currentCar;
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
            if (Simulator.gameTime % 50 ==0)
            {
                Debug.Log("Координата машины (ее скорость): " + car.getX() + " (" + car.getSpeed() + ") ");
            }
          
        }
    }
    
   
}
