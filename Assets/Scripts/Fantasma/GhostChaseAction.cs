/*    
   Copyright (C) 2020-2023 Federico Peinado
   http://www.federicopeinado.com
   Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
   Esta asignatura se imparte en la Facultad de Informática de la Universidad Complutense de Madrid (España).
   Autor: Federico Peinado 
   Contacto: email@federicopeinado.com
*/

using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;

/*
 * Accion de seguir a la cantante, cuando la alcanza devuelve Success
 */

public class GhostChaseAction : Action
{
    NavMeshAgent agent;

    [SerializeField]
    SharedGameObject singer;

    public override void OnAwake()
    {
        // IMPLEMENTAR 
        agent = GetComponent<NavMeshAgent>();
        singer = Owner.GetVariable("Cantante") as SharedGameObject;
    }

    public override TaskStatus OnUpdate()
    {
        // 
        agent.SetDestination(singer.Value.transform.position);

        if (Vector3.Distance(transform.position, singer.Value.transform.position) < 2f)
        {
            singer.Value.GetComponent<Cantante>().capturadaPor(this.transform);
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
    }
}
