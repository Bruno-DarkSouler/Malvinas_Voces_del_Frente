using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float timeMultiplier;
    [SerializeField] private GameObject enemigos;
    public float timePassed;

    public bool timeIsRunning = false;
    
    public int hours;
    // public int trueHours;
    public int minutes;
    // public int trueMinutes;
    public int days = 2;
    private float dayPorcentaje;

    private bool startedExisting = false;
    private bool messageSent = false;
    private bool messageSent2 = false;
    private bool[] isTimeEvent = {false, false};
    private bool[] eventIsDone = {false, false};

    public Light2D sunLight;
    public Gradient dayTimeColor;
    // Start is called before the first frame update
    void Start()
    {
        timeMultiplier = 60;
        timePassed = 10800;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeIsRunning)
        {
            
            timePassed += Time.deltaTime * timeMultiplier;

            // trueMinutes = (int) timePassed / 60;
            // trueMinutes = (int) timePassed / 3600;

            minutes = (int) timePassed / 60 % 60;
            hours = (int) timePassed / 3600 % 24;
            dayPorcentaje = (float) hours / 24;

            sunLight.color = dayTimeColor.Evaluate(dayPorcentaje);

            if(hours % 24 == 0)
            {
                days++;
            }

            if(timePassed > 0 && !startedExisting)
            {
                RadioController.Instance.ShowMessage("", 0f);
                startedExisting = true;
            }

            if(timePassed / 60 > 300 && !messageSent)
            {
                RadioController.Instance.ShowMessage("Se le informa a todas las unidades que estamos rodeados por el enemigo.", 3f);
                messageSent = true;
            }

            if(timePassed / 60 > 305 && !messageSent2)
            {
                RadioController.Instance.ShowMessage("Daremos la rendición sin oponer resistencia.", 3f);
                messageSent2 = true;
            }
            // Debug.Log("Hola");
            // Debug.Log(minutes);
            // Debug.Log(days);
            // Debug.Log(minutes);
            // Debug.Log(hours);
        }

        if (hours >= 6 && !eventIsDone[0])
        {
            enemigos.SetActive(true);
            eventIsDone[0] = true;
        }
        // Debug.Log("Hola");
        // Debug.Log(minutes);
        // Debug.Log(days);
        // Debug.Log(minutes);
        // Debug.Log(hours);

    }
}
