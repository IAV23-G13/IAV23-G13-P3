/*    
   Copyright (C) 2020-2023 Federico Peinado
   http://www.federicopeinado.com
   Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
   Esta asignatura se imparte en la Facultad de Informática de la Universidad Complutense de Madrid (España).
   Autor: Federico Peinado 
   Contacto: email@federicopeinado.com
*/

using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class PublicoCondition : Conditional
{
    //GameBlackboard blackboard;
    SharedGameObject blackboard;

    [SerializeField] bool publicoWest;
    [SerializeField] bool publicoEast;

    public override void OnAwake()
    {
        //blackboard = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>();
       blackboard = Owner.GetVariable("BlackBoard") as SharedGameObject;

    }

    public override TaskStatus OnUpdate()
    {
        GameObject bb = blackboard.Value as GameObject;
        if (bb.GetComponent<GameBlackboard>().eastLever.gameObject.GetComponentInChildren<ControlPalanca>().caido)
        {
            publicoEast = false;
        }
        else
        {
            publicoEast = true;
        }

        if (bb.GetComponent<GameBlackboard>().westLever.gameObject.GetComponentInChildren<ControlPalanca>().caido)
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
