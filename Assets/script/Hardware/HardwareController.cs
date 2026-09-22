using System;
using System.IO.Ports;
using UnityEngine;

public class ArduinoController : MonoBehaviour
{
    [Header("Arduino")]
    public string portName = "COM3";
    public int baudRate = 115200;

    private SerialPort serialPort;

    // Estado de los cuatro botones de movimiento
    public bool wPressed;
    public bool aPressed;
    public bool sPressed;
    public bool dPressed;

    // Eventos para los botones de acción
    public event Action Button5Pressed;
    public event Action Button6Pressed;
    public event Action Button7Pressed;

    public bool hardwareDisconected;

    void Start()
    {
        try
        {
            serialPort = new SerialPort(portName, baudRate);
            serialPort.ReadTimeout = 10;
            serialPort.Open();

            hardwareDisconected = false;
            Debug.Log("Arduino conectado en " + portName);
        }
        catch (Exception e)
        {
            hardwareDisconected = true;
            Debug.LogError("No se pudo conectar con Arduino: " + e.Message);
        }
    }

    void Update()
    {
        if (serialPort == null || !serialPort.IsOpen)
            return;

        try
        {
            while (serialPort.BytesToRead > 0)
            {
                string message = serialPort.ReadLine().Trim();

                ProcessMessage(message);
            }
        }
        catch (TimeoutException)
        {
            // No hay problema: simplemente no había datos disponibles.
        }
    }

    void ProcessMessage(string message)
    {
        switch (message)
        {
            case "W_DOWN":
                wPressed = true;
                break;

            case "W_UP":
                wPressed = false;
                break;

            case "A_DOWN":
                aPressed = true;
                break;

            case "A_UP":
                aPressed = false;
                break;

            case "S_DOWN":
                sPressed = true;
                break;

            case "S_UP":
                sPressed = false;
                break;

            case "D_DOWN":
                dPressed = true;
                break;

            case "D_UP":
                dPressed = false;
                break;

            case "BUL":
                Button5Pressed?.Invoke();
                break;

            case "INT":
                Button6Pressed?.Invoke();
                break;

            case "EXT":
                Button7Pressed?.Invoke();
                break;
        }
    }

    void OnDestroy()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}