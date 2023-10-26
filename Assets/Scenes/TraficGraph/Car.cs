using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car
{
    private float x; // Координата
    private float speed; // Скорость
    private float distanceToNextCar = 0; // Расстояние до следующей машины
    private float timeEnterRoad;  // Время заезда на дорогу
    private String[] path; // Путь
    private int current = 0; // Текущее местоположение, относительно массива path
    public Car(float x, float speed, String[] path)
    {
        this.x = x;
        this.speed = speed;
        this.path = path;
    }

    public float getX()
    {
        return x;
    }
    public float getSpeed()
    {
        return speed;
    }

    public float getDistanceToNextCar()
    {
        return distanceToNextCar;
    }

    public float getTimeEnterRoad()
    {
        return timeEnterRoad;
    }
    public void changeCoordinate()
    {
        x = speed * (Simulator.gameTime - timeEnterRoad);
    }

    public void changeTime(float time)
    {
        timeEnterRoad = time;
    }
    public void changeDistance(float newDistance)
    {
        distanceToNextCar = newDistance;
    }

    public void changeCoordinate(float x)
    {
        this.x = x;
    }

    public void changeSpeed(float speed)
    {
        this.speed = speed;
    }

    public String[] getPath()
    {
        return path;
    }

    public void nextNode()
    {
        current += 1;
    }

    public int getCurrent()
    {
        return current;
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
