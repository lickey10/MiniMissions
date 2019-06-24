using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterDistanceCulling : MonoBehaviour {
	public Transform cam;
	public bool cullself;
	public List<GameObject> RendersToCull;
	public float CullingDistance=140;
	private float distance;
	private bool cull;
	private bool render;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	distance=Vector3.Distance(cam.position, transform.position);
		
	if(cull){
			
		int listsize=RendersToCull.Count;
			for (int i = 0; i < listsize; i++){
				if(RendersToCull[i].GetComponent<Renderer>().enabled){
			RendersToCull[i].GetComponent<Renderer>().enabled=false;
				}
				
			}
			if(cullself){
				if(GetComponent<Renderer>().enabled){
					GetComponent<Renderer>().enabled=false;
				}
			}
			
		}
	
	if(render){
			
		int listsize=RendersToCull.Count;
			for (int i = 0; i < listsize; i++){
				if(RendersToCull[i].GetComponent<Renderer>().enabled){}
				else RendersToCull[i].GetComponent<Renderer>().enabled=true;
		
		}	
			if(cullself){
				if(GetComponent<Renderer>().enabled){}
					else GetComponent<Renderer>().enabled=true;
				
			}
		}
		
		if(distance>=CullingDistance){
			cull=true;
			render=false;
		}
		else{
		render=true;
			cull=false;
		}
		
		
	}
}
