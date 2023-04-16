/*    
   Copyright (C) 2020-2023 Federico Peinado
   http://www.federicopeinado.com
   Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
   Esta asignatura se imparte en la Facultad de Informática de la Universidad Complutense de Madrid (España).
   Autor: Federico Peinado 
   Contacto: email@federicopeinado.com
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;

/*
 * Accion de ir a la sala de musica, cuando llega devuelve Success
 */

public class GhostReturnAction : Action
{
    Transform musicRoom;
    NavMeshAgent ghost;
    public override void OnAwake()
    {
        // IMPLEMENTAR
        ghost = GetComponent<NavMeshAgent>();
        musicRoom = GameObject.FindGameObjectWithTag("MusicRoom").transform;
        ghost.destination = musicRoom.position;
        //gameObject.GetComponent<NavMeshAgent>().destination = musicRoom.position;
    }

    public override TaskStatus OnUpdate()
    {
        // IMPLEMENTAR
        //return TaskStatus.Failure;

        if (ghost.remainingDistance <= 2)
            return TaskStatus.Success;
        else return TaskStatus.Running; 
    }

    //OnDestinationReached()
    //{
    //    if (agent.remainingDistance <= agent.stoppingDistance)
    //    {
    //        return TaskStatus.Success;
    //    }

        //agent.
    //}
}