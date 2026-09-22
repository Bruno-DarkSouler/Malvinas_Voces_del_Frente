using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enrmigo : MonoBehaviour
{
    public Transform player;//Jugador
    [SerializeField] private float distance;//Distancia minima
    [SerializeField] private float enemySpeed;//Velocidad(hay que poner valores altos(supongo por el deltatime))
    [SerializeField] private float separationRadius = 1.0f; // <--- NUEVO: Radio de detección para separarse
    private Rigidbody2D rb;//Enemigo
    private Vector2 movement;//Movimiento
    private Animator animator;
    public PlayerStates control;
    public float enemyHP;
    

    void Start()
    {
        control = FindObjectOfType<PlayerStates>();
        animator = GetComponent<Animator>();
        enemyHP = 100;
    }

    void Update()
    {
        Follow();
        Separate(); // <--- NUEVO: Llamamos a la función de separación en cada frame
        Dead();
    }

    void Follow()
    {
        if (Vector2.Distance(transform.position, player.position) > distance)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                direction = new Vector2(Mathf.Sign(direction.x), 0);
            }
            else
            {
                direction = new Vector2(0, Mathf.Sign(direction.y));
            }
            transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);
            animator.SetFloat("movexE", direction.x);
            animator.SetFloat("moveyE", direction.y);
            animator.SetBool("IsMoving", true);
            //Debug.Log("X: " + direction.x + " Y: " + direction.y);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    void Dead()
    {
        if (enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Separa a los enemigos para no quedar unos encima de otros
    void Separate()
    {
        //  Busca los collider en el radio indicado con Physics2D.OverlapCircleAll
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, separationRadius);
        
        foreach (Collider2D col in colliders)
        {
            // Comprobamos si es otro enemigo y si tiene el script de los enemigos
            if (col.gameObject != gameObject && col.GetComponent<enrmigo>() != null)
            {
                // Calculamos la dirección opuesta al enemigo que detectamos
                Vector2 directionAway = (transform.position - col.transform.position).normalized;
                
                // Se mueve a la direccion opuesta(no tiene animacion(creo))
                transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + directionAway, enemySpeed * Time.deltaTime);
            }
        }
    }
}