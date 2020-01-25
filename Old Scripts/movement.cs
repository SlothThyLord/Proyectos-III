using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody myrb;
    public float forceSpeed; // Al hacerla pública, nos sale en la interfaz de Unity.
    public float forceRotation;

    // Start is called before the first frame update
    void Start()
    {
        myrb = GetComponent<Rigidbody>(); // Necesario para decirle que estamos cogiendo el "rigidbody" del objeto
                                          // sobre el que estamos creando el script. Cuando declaramos la variable
                                          // simplemente decimos el tipo del que es, pero después necesitamos decir
                                          // cuál es esa variable. Como queremos centrarnos en el objeto, hacemos
                                          // 'GetComponent'.
        this.forceRotation = 10;
        this.forceSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // Estos métodos nos cogen lo que se introduce desde flexas en
        float moveZ = Input.GetAxis("Vertical"); // teclado o el mando que sea.
        Vector3 direction = new Vector3(moveZ, 0, -moveX); // Creamos este vector para usarlo en los métodos siguientes.
                                                      // Otra opción sería hacer 'transform.forward'. Pero no es lo mismo,
                                                      // si usamos el vector, es una manera de usar las direcciones del
                                                      // mundo (la escena general); si, por el contrario, usamos la
                                                      // 'transform', nos moveríamos en las direcciones del mismo personaje.
        myrb.AddForce(direction * forceSpeed);                // Unity recomienda que estos 2 métodos (addForce, addTorque)
        myrb.AddTorque(transform.up * forceRotation * moveX); // no se escriban aquí, sino en un método nuevo llamado
                                                              // 'private void FixedUpdate()'.
        myrb.velocity = direction * forceSpeed;
        myrb.MovePosition(transform.position + (direction * forceSpeed * Time.deltaTime));
    }
}