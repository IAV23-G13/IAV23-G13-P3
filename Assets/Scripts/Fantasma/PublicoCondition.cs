/*    
   Copyright (C) 2020-2023 Federico Peinado
   http://www.federicopeinado.com
   Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
   Esta asignatura se imparte en la Facultad de Informática de la Universidad Complutense de Madrid (España).
   Autor: Federico Peinado 
   Contacto: email@federicopeinado.com
*/

using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicoCondition : Conditional
{
    GameBlackboard blackboard;

    [SerializeField] bool publicoWest;
    [SerializeField] bool publicoEast;

    public override void OnAwake()
    {
        blackboard = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>();
        publicoEast = true;
        publicoWest = true;
        
    }

    public override TaskStatus OnUpdate()
    {
        if (blackboard.eastLever.gameObject.GetComponentInChildren<ControlPalanca>().caido)
        {
            publicoEast = false;
        }
        else
        {
            publicoEast = true;
        }

        if (blackboard.westLever.gameObject.GetComponentInChildren<ControlPalanca>().caido)
        {
            publicoWest = false;
        }
        else
        {
            publicoWest = true;
        }
        if (!publicoWest&&!publicoEast)
       
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }
}
