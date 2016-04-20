using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PathDefinition : MonoBehaviour{

	// Stores the points of a platforms path
	public Transform[] Points;


	// Iterates through each index in order.
	// Reverses the order once it reaches the end
	public IEnumerator<Transform> GetPathEnumberator(){
		if (Points == null || Points.Length < 1)
			yield break;

		var direction = 1;
		var index = 0;
		while (true) 
		{
			yield return Points [index];

			if (Points.Length == 1)
				continue;

			if (index <= 0)
				direction = 1;
			else if (index >= Points.Length - 1)
				direction = -1;
			index = index + direction;
		}
		throw new NotImplementedException(); 
}

	// Draws a line between multiple GameObjects
	public void OnDrawGizmos()
	{
		if (Points == null || Points.Length < 2)
			return;

		for (var i=1; i < Points.Length; i++)
		{
			Gizmos.DrawLine(Points[i-1].position, Points[i].position);
		}
		
}
}
