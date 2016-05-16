using UnityEngine;


static class Grid{

	public static AudioManager audio;


	static Grid(){
	
		GameObject g;

		g = safeFind ("__AudioManager");
		audio = (AudioManager)SafeComponent (g, "AudioManager");

	}

	public static void SayHello(){
		Debug.Log ("Confirming to developer that the Grid is working fine.");
	}

	private static GameObject safeFind(string s){
		GameObject g = GameObject.Find (s);
		if (g == null)
			BigProblem ("The " + s + " game object is not in this scene.");
		return g;
	}

	private static Component SafeComponent(GameObject g, string s){
		Component c = g.GetComponent (s);
		if (c == null)
			BigProblem ("The " +s+ " component is not there");
		return c;
	}
		
	private static void BigProblem(string error){
		for (int i=10;i>0;--i) Debug.LogError(" >>>>>>>>>>>> Cannot proceed... " +error);
		for (int i=10;i>0;--i) Debug.LogError(" !!! Is it possible you just forgot to launch from scene zero, the __preEverythingScene scene.");
		Debug.Break();
	}
}
