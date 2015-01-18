using UnityEngine;
using System.Collections;
using SmoothMoves;	// using SmoothMoves

public class FlowerAnimationButton : MonoBehaviour {
	
	public BoneAnimation Hero;
	static public int count = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	// Play Animation according to the ClipCount
	Hero.Play(count);
	}

	// Swap Animation button;
	void OnGUI(){
	if(count < Hero.GetClipCount()){
		if(GUILayout.Button (Hero.GetAnimationClipName(count))) {
            		
				if(count < Hero.GetClipCount()-1){
					count ++;
				}else{
					count = 0;
				}
        	}
		}
	}
}
