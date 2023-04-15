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
using Unity.VisualScripting;
using System.Threading;
using BehaviorDesigner.Runtime;

/*
 * Devuelve Success cuando la cantante es sobre el palco
 */


public class VizcondeChocaCondition : Conditional
{
    SharedGameObject Vizconde;
   // NavMeshAgent agent;

    //CapsuleCollider cc;
    //CapsuleCollider cc2;
    bool golpeado = false;

    public override void OnAwake()
    {
        Vizconde = Owner.GetVariable("Player") as SharedGameObject;
        //cc = GameObject.FindGameObjectWithTag("Ghost").GetComponent<CapsuleCollider>();
        //cc2 = Vizconde.GetComponent<CapsuleCollider>();
        // IMPLEMENTAR 

    }

    public override TaskStatus OnUpdate()
    {
        //hacerlo con el on coliision directamente hay un ejemplo en el nodo del arbol de condicion colision
        // IMPLEMENTAR
        if(golpeado)
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;

    }

    public override void OnCollisionEnter(Collision collision)
    {
        GameObject player=Vizconde.Value as GameObject;
        if (collision.gameObject==player)
        {
            golpeado = true;
        }
    }

    public override void OnEnd()
    {
        golpeado = false;
    }
}
