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
    SharedTransform musicRoom;
    SharedGameObject ghost;
    
    public override void OnAwake()
    {
        // IMPLEMENTAR
        //musicRoom = GetVariable("MusicRoom") as SharedGameObject;
        //ghost = GetVariable("Ghost") as SharedGameObject;
        //ghost.agent.SetDestination(musicRoom.position);
    }

    public override TaskStatus OnUpdate()
    {
        // IMPLEMENTAR
        return TaskStatus.Failure;
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