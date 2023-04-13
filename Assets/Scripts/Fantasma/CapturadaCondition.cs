﻿/*    
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
using BehaviorDesigner.Runtime;

/*
 * Condicion de si la cantante esta encarcelada
 */

public class CapturadaCondition : Conditional
{
    SharedGameObject cantante;

    public override void OnAwake()
    {
        // IMPLEMENTAR
        cantante= Owner.GetVariable("Piano") as SharedGameObject;
    }

    public override TaskStatus OnUpdate()
    {
        // IMPLEMENTAR
        GameObject cant = cantante.Value as GameObject;

        if (cant.GetComponent<Cantante>().capturada)
            return TaskStatus.Success;
        else 
            return TaskStatus.Failure;
    }
}