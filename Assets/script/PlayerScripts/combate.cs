using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlCamara : MonoBehaviour
{
    [SerializeField] private GameObject bulletP;//Prefab de la bala
    [SerializeField] private float bulletSpeed;//Velocidad
    [SerializeField] private float shootDelay;// un pequeño delay
    private float lastShoot;//Detecta el ultimo disparo para poner el delay
    public float enemyDamage;

    public topdownmovent movement;
    public ArduinoController arduinoController;

    void Start()
    {
        arduinoController.Button5Pressed += HardwareShoot;
    }

    void Update()
    {
        float horShoot = Input.GetAxisRaw("ShootHorizontal");//Teclas de disparo horizontal y abajo la vertical(alfinal lo hice con flechas, si quieren lo puedo cambiar)
        float verShoot = Input.GetAxisRaw("ShootVertical");

        if((horShoot != 0 || verShoot != 0) && Time.time > lastShoot + shootDelay)//Establece cuando se ejecuta el disparo teniendo en cuenta el delay
        {
            shoot(horShoot, verShoot);//Dispara
            lastShoot = Time.time;//Guarda el ultimo disparo(para el delay de arriba(esto tambien por si hacemos varias armas lo vamos modificando y asi))
        }
    }

    void HardwareShoot()
    {
        shoot(movement.GetMovex(), movement.GetMovey());
    }

    void shoot(float x, float y)
    {
        GameObject bullet = Instantiate(bulletP, transform.position, transform.rotation) as GameObject;//instanciamos las balas
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;//sin gravedad por ser un top-down
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y) * bulletSpeed;//la velocidad de las balas y direccion al disparar
    }
}
