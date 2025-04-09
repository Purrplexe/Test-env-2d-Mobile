using NUnit.Framework;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.Windows;
using TMPro;

public class AccelTest : MonoBehaviour
{

    public int currentTest = 0;
    private float currentTime = 0;
    public float testTime = 10;
    private bool isRunning = false;

    public TMP_Text text;

    struct Datapoint
    {
        public float time;
        public Vector3 acceleration;

        public Datapoint(float now, Vector3 acceleration) : this()
        {
            this.time = now;
            this.acceleration = acceleration;
        }
    }

    List<Datapoint> datapoints = new List<Datapoint>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        
    }
    private void OnEnable()
    {
        InputSystem.EnableDevice(Accelerometer.current);
    }
    private void OnDisable()
    {
        InputSystem.DisableDevice(Accelerometer.current);
    }
    private void FixedUpdate()
    {
        if (isRunning)
        {
            Vector3 acceleration = Accelerometer.current.acceleration.ReadValue();
            datapoints.Add(new Datapoint(Time.time, acceleration));
            Debug.Log(acceleration);
            currentTime += Time.fixedDeltaTime;
            if (currentTime > testTime)
            {
                isRunning = false;
                SaveData();
            }
        }
    }


    private void SaveData()
    {
        text.text = "Test " + currentTest.ToString() + " ´Done";
        var sr = System.IO.File.CreateText(Application.persistentDataPath + "/test" + currentTest.ToString() + ".txt");
        foreach (Datapoint datapoint in datapoints)
        {
            sr.WriteLine(datapoint.time + ";" + datapoint.acceleration.x + "; "+ datapoint.acceleration.y + "; " + datapoint.acceleration.z);
        }
        sr.Close();
    }

    public void StartTest()
    {
        currentTime = 0;
        datapoints.Clear();
        isRunning = true;
        text.text = "Test " + currentTest.ToString() + " is running";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
