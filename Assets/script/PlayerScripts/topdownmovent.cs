using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topdownmovent : MonoBehaviour
{
    //Solo con esto tenemos el movimiento del personaje
    //Variables de referencia para la velocidad y direccion
    public float speed;
    [SerializeField] private Vector2 direction;
    private Rigidbody2D rb2D;
    //Para la animacion
    [SerializeField] private float movex;
    [SerializeField] private float movey;
    private Animator animator;

    public ArduinoController hardwareController;

    public float GetMovex()
    {
        return movex;
    }

    public float GetMovey()
    {
        return movey;
    }

    //Funcion para iniciar(siempre en mayuscula, son funciones de unity)
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    //Funcion para actualizar(siempre en mayuscula)
    private void Update()
    {
        movex = Input.GetAxisRaw("Horizontal");
        movey = Input.GetAxisRaw("Vertical");
        if (!hardwareController.hardwareDisconected)
        {
            if (hardwareController.wPressed)
            {
                movey = -1;
            }

            if (hardwareController.aPressed)
            {
                movex = -1;
            }

            if (hardwareController.sPressed)
            {
                movey = 1;
            }

            if (hardwareController.dPressed)
            {
                movex = 1;
            }
        }
        animator.SetFloat("movex", movex);//Animacion en x(izquierda y derecha)
        animator.SetFloat("movey",movey);//Animacion en y(arriba y abajo)
        //Parte del funcionamiento de la animacion idle(para estar quieto)
        if (movex != 0 || movey != 0) {
            animator.SetFloat("finx", movex);
            animator.SetFloat("finy", movey);
        }
        direction = new Vector2(movex, movey).normalized;
        // Debug.Log("movex: " + movex.ToString());
        // Debug.Log("movey: " + movey.ToString());
    }
    //Otra funcion para actualizar(siempre en mayuscula)
    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + direction * speed * Time.fixedDeltaTime);
    }
}
