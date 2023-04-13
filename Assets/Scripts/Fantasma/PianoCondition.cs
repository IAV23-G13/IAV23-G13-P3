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
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PianoCondition : Conditional
{
   SharedGameObject piano;

    public override void OnAwake()
    {
        //piano = GameObject.FindGameObjectWithTag("Piano").GetComponent<ControlPiano>();
        piano = Owner.GetVariable("Piano") as SharedGameObject;
        // IMPLEMENTAR
    }

    public override TaskStatus OnUpdate()
    {
        // IMPLEMENTAR
        //if(piano.roto)
        //guardar un 
        GameObject cp=piano.Value as GameObject;
       if(cp.GetComponent<ControlPiano>().roto)
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }
}
