﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour {

	#region Variables
	public Transform target;
	public Vector3 offSet = new Vector3 (1,1,-1);
	
	//El offset es para simplificar codigo y posicionar la cámara donde quueramos pudiendo aun así seguir al jugador. Si no me crees borralo.


	#endregion

	#region Unity Methods
	//LateUpdate porque primero se mueve el jugador y luego la camara. Hay que esperar a que se actualice la nueva pos del jugador para luego seguirlo.
    void LateUpdate()
    {
	    if(target!=null)transform.position = target.position + offSet;
		//Alternativa
		//transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
	#endregion

	#region Personal Methods
	#endregion
	
}
