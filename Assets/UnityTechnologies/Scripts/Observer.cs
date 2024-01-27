using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{//esto buscara la posicion del jugador en vez del gameObject, es mas preciso
    public Transform player;
    bool m_IsPlayerInRange;
    public GameEnding gameEnding;

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }
    //Dependiendo de si el personaje está en line of sight, el booleana será true o false
    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }


    private void Update()
    {
        if(m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }

}



