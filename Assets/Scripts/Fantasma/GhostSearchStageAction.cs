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
using UnityEditor.Experimental.GraphView;

/*
 * Accion de ir al escenario, cuando llega devuelve Success
 */

public class GhostSearchStageAction : Action
{
    NavMeshAgent agent;
    Transform stage;
    GameBlackboard GameBlackboard;
    GameObject target;
    bool bothdown = false;
    public override void OnAwake()
    {
        // IMPLEMENTAR 
        agent = GetComponent<NavMeshAgent>();
        stage = (Owner.GetVariable("escenario") as SharedTransform).Value;
        GameBlackboard = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>();
        target = GameBlackboard.nearestLever(gameObject);
        agent.destination = target.transform.position;
    }

    private bool AreBothDown()
    {
        bool areThey = GameBlackboard.nearestLever(gameObject) == null;
        if (!areThey)
        {
            //Todo menos el vestibulo
            agent.areaMask = (1 << 0) | (1 << 1) | (1 << 2) | (1 << 4) | (1 << 5) | (1 << 6) | (1 << 7) | (1 << 8) | (1 << 9) | (1 << 10) | (1 << 11) | (1 << 12) |
                (1 << 13) | (1 << 14);
        }

        else agent.areaMask = -1;
        return areThey;
    }

    public override TaskStatus OnUpdate()
    {
        // 
        //


        if (Vector3.Distance(transform.position, target.transform.position) < 2f && !AreBothDown())
        {
            target.GetComponentInChildren<ControlPalanca>().caido = true;
            if (!AreBothDown())
            {
                target = GameBlackboard.nearestLever(gameObject);
                return TaskStatus.Running;
            }
            return TaskStatus.Success;
        }
        else if (AreBothDown()) return TaskStatus.Success;
        else
        {
            agent.destination = target.transform.position;
            return TaskStatus.Running;
        }
    }
}