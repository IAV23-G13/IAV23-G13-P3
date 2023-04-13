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

/*
 * Devuelve Success cuando la cantante es sobre el palco
 */


public class VizcondeChocaCondition : Conditional
{
    GameObject Vizconde;
    NavMeshAgent agent;

    CapsuleCollider cc;
    CapsuleCollider cc2;
    bool golpeado = false;

    public override void OnAwake()
    {
        Vizconde= GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
        cc = GameObject.FindGameObjectWithTag("Ghost").GetComponent<CapsuleCollider>();
        cc2 = Vizconde.GetComponent<CapsuleCollider>();
        // IMPLEMENTAR 

    }

    public override TaskStatus OnUpdate()
    {
        //hacerlo con el on coliision directamente hay un ejemplo en el nodo del arbol de condicion colision
        // IMPLEMENTAR
        return TaskStatus.Success;

    }

   

}
