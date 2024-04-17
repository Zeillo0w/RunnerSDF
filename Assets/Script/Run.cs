using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public Transform left;
    public Transform right;
    public int step;

    private Rigidbody rb; // Référence au composant Rigidbody

    private bool isJumping = false; // Variable pour suivre si le personnage est en train de sauter

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Récupérer le composant Rigidbody au démarrage
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && step < 1)
        {
            transform.position = right.position; // Utilisation directe de right.position sans GetComponent
            step++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && step > -1)
        {
            transform.position = left.position; // Utilisation directe de left.position sans GetComponent
            step--;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) // Ajout d'une condition pour vérifier si le personnage est déjà en train de sauter
        {
            rb.AddForce(Vector3.up * 10f, ForceMode.Impulse); // Ajoute une force vers le haut pour simuler un saut
            isJumping = true; // Met à jour le statut de saut
        }
    }

    // Utiliser FixedUpdate pour gérer les mouvements physiques
    void FixedUpdate()
    {
        if (!isJumping)
        {
            // Simulation de la gravité seulement si le personnage n'est pas en train de sauter
            rb.AddForce(Vector3.down * 10f, ForceMode.Force); // Ajoute une force vers le bas pour simuler la gravité
        }
        else
        {
            // Si le personnage est en train de sauter, nous devons vérifier s'il est retourné au sol
            // Si le personnage est retourné au sol, nous réinitialisons la variable isJumping
            if (Physics.Raycast(transform.position, Vector3.down, 0.6f))
            {
                isJumping = false;
            }
        }
    }
}
