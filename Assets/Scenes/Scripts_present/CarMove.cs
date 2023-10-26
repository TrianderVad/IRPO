using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    private Car cars = null;

    public void setCar(Car car)
    {
        this.cars = car;
    }
    //private Car car = Simulator.GetCar();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cars != null) { 
        transform.localPosition = new Vector3(cars.getX(), 0);
        }
    }
}
