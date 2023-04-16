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
 * Accion de ir al escenario, cuando llega devuelve Success
 */

public class GhostSearchStageAction : Action
{
    NavMeshAgent agent;
    Transform stage;

    public override void OnAwake()
    {
        // IMPLEMENTAR 
        agent = GetComponent<NavMeshAgent>();
        stage = (Owner.GetVariable("escenario") as SharedTransform).Value;
    }

    public override TaskStatus OnUpdate()
    {
        // 
        agent.SetDestination(stage.position);

        if (Vector3.Distance(transform.position, stage.position) < 2f)
        {
            stage.GetComponent<Cantante>().capturadaPor(this.transform);
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
    }
}