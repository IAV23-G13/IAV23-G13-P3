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
 * Accion de seguir a la cantante, cuando la alcanza devuelve Success
 */

public class GhostLlevarCantante : Action
{
    NavMeshAgent agent;
    NavMeshAgent singerNav;
    GameObject singer;
    Transform palancaCelda;

    bool gateOpen;
    bool yendoACelda;

    GameObject celda;

    bool started = false;

    public override void OnAwake()
    {
        agent = GetComponent<NavMeshAgent>();

        celda = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>().celda;
        singer = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>().singer;
        singerNav = singer.GetComponent<NavMeshAgent>();

        gateOpen = (Owner.GetVariable("BlackBoard") as SharedGameObject).Value.GetComponent<GameBlackboard>().gate;
        palancaCelda = (Owner.GetVariable("palancaCelda") as SharedTransform).Value;
    }

    public override TaskStatus OnUpdate()
    {
        if (singer.GetComponent<Cantante>().objetivo == transform)
        {
            gateOpen = (Owner.GetVariable("BlackBoard") as SharedGameObject).Value.GetComponent<GameBlackboard>().gate;

            if (!started || (agent.destination != celda.transform.position && agent.destination != palancaCelda.position))
            {
                if (gateOpen)
                {
                    agent.SetDestination(celda.transform.position);
                    yendoACelda = true;
                }
                else
                {
                    agent.SetDestination(palancaCelda.position);
                    yendoACelda = false;
                }
                started = true;
            }

            if (yendoACelda && !gateOpen)
            {
                agent.SetDestination(palancaCelda.position);
                yendoACelda = false;
            }
            else if (!yendoACelda && gateOpen)
            {
                agent.SetDestination(celda.transform.position);
                yendoACelda = true;
            }

            if (yendoACelda)
            {
                if (Vector3.Distance(transform.position, celda.transform.position) < 2f)
                {
                    agent.SetDestination(palancaCelda.position);
                    yendoACelda = false;
                    singer.GetComponent<Cantante>().capturadaPor();
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, palancaCelda.position) < 2f)
                {
                    palancaCelda.GetComponent<PalancaPuerta>().Interact();
                    agent.SetDestination(celda.transform.position);
                    yendoACelda = true;
                }
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, palancaCelda.position) < 2f)
            {
                palancaCelda.GetComponent<PalancaPuerta>().Interact();
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Running;

    }
}
