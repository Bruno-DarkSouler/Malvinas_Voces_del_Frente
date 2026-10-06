using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class ArgSoldiers : MonoBehaviour
{
    [Header("Configuracion del movimiento")]
    public float speed = 6f;

    [Header("Configuracion del movimiento")]
    [Tooltip("Camino inicial para llegar al lugar del evento")]
    public int pathTime;
    public int pathTime2;
    public int pathTime3;
    public int pathTime4;
    public int pathTime5;
    public Transform[] onceWaypoints;
    public bool pathDone = false;
    public Transform[] onceWaypoints2;
    private Animator animator;
    [SerializeField] private float separacion = 1.0f;

    public bool pathDone2 = false;

    public Transform[] onceWaypoints3;
    
    public bool pathDone3 = false;

    public Transform[] onceWaypoints4;
    
    public bool pathDone4 = false;

    public Transform[] onceWaypoints5;
    
    public bool pathDone5 = false;

    private int currentOnceIndex = 0;
    private bool finishedPath = false;
    public string dialogues = null;
    public int currentStage = 0;
    public TimeManager timeManager;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // if(timeManager.minutes > 40 && timeManager.hours == 11)

        //Debug.Log("-----------Tiempo-------------");
        //Debug.Log(currentStage);
        //Debug.Log(timeManager.minutes / 60);
        //Debug.Log(pathDone);
        //Debug.Log(finishedPath);
        //Debug.Log("-----------Tiempo-------------");
        Separate();
        animator.SetBool("IsMoving", false);//Le decimos que se quede quieto
        if (currentStage == 0 && timeManager.timePassed / 60 > pathTime)
        {
            currentStage = 1;
        }

        if(currentStage == 1 && timeManager.timePassed / 60 > pathTime2)
        {
            currentStage = 2;
        }

        if(currentStage == 2 && timeManager.timePassed / 60 > pathTime3)
        {
            currentStage = 3;
        }

        if(currentStage == 3 && timeManager.timePassed / 60 > pathTime4)
        {
            currentStage = 4;
        }

        if(currentStage == 4 && timeManager.timePassed / 60 > pathTime5)
        {
            currentStage = 5;
        }



        switch(currentStage)
        {
            case 1:
                if (!finishedPath && !pathDone)
                {
                    FollowPath(onceWaypoints, currentOnceIndex);
                }
                else
                {
                    pathDone = true;
                    finishedPath = false;
                }
            break;

            case 2:
                if (!finishedPath && !pathDone2)
                {
                    FollowPath(onceWaypoints2, currentOnceIndex);
                }
                else
                {
                    pathDone2 = true;
                    finishedPath = false;
                }
            break;

            case 3:
                if (!finishedPath && !pathDone3)
                {
                    FollowPath(onceWaypoints3, currentOnceIndex);
                }
                else
                {
                    pathDone3 = true;
                    finishedPath = false;
                }
            break;

            case 4:
                if (!finishedPath && !pathDone4)
                {
                    FollowPath(onceWaypoints4, currentOnceIndex);
                }
                else
                {
                    pathDone4 = true;
                    finishedPath = false;
                }
            break;

            case 5:
                if (!finishedPath && !pathDone5)
                {
                    FollowPath(onceWaypoints5, currentOnceIndex);
                }
                else
                {
                    pathDone5 = true;
                    finishedPath = false;
                }
            break;

            default:
            break;
        }
    }

    private void FollowPath(Transform[] waypointsPath, int index)
    {
        if (index >= waypointsPath.Length)
        {
            finishedPath = true;
            currentOnceIndex = 0;
            return;
        }
        Transform targetWaypoint = waypointsPath[index];
        Vector2 direction = (targetWaypoint.position - transform.position).normalized;
        //Calcula donde esta yendo el soldado
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            direction = new Vector2(Mathf.Sign(direction.x), 0);
        }
        else
        {
            direction = new Vector2(0, Mathf.Sign(direction.y));
        }
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
        animator.SetFloat("moveX", direction.x);//Le pasamos al blendtree un valor para ejecutar las animaciones en X 
        animator.SetFloat("moveY", direction.y);//Le pasamos al blendtree un valor para ejecutar las animaciones en Y
        animator.SetBool("IsMoving", true);//Le decimos que se mueva

        if (Vector2.Distance(transform.position, targetWaypoint.position) < 1f)
        {
            currentOnceIndex++;
        }
    }

    void Separate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, separacion);
        
        foreach (Collider2D col in colliders)
        {
            if (col.gameObject != gameObject && col.GetComponent<ArgSoldiers>() != null)
            {
                Vector2 directionAway = (transform.position - col.transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + directionAway, speed * Time.deltaTime);
            }
        }
    }
}
