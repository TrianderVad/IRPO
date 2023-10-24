using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private long x; // ����������
    private long speed; // ��������
    private long distanceToNextCar = 0; // ���������� �� ��������� ������
    private long timeEnterRoad;  // ����� ������ �� ������
    private String[] path; // ����
    private int current = 0; // ������� ��������������, ������������ ������� path
    public Car(long x, long speed, String[] path)
    {
        this.x = x;
        this.speed = speed;
        this.path = path;
    }

    public long getX()
    {
        return x;
    }
    public long getSpeed()
    {
        return speed;
    }

    public long getDistanceToNextCar()
    {
        return distanceToNextCar;
    }

    public long getTimeEnterRoad()
    {
        return timeEnterRoad;
    }
    public void changeCoordinate()
    {
        x = speed * (Simulator.gameTime - timeEnterRoad);
    }

    public void changeTime(long time)
    {
        timeEnterRoad = time;
    }
    public void changeDistance(long newDistance)
    {
        distanceToNextCar = newDistance;
    }

    public void changeCoordinate(long x)
    {
        this.x = x;
    }

    public void changeSpeed(long speed)
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
