using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDragController : MonoBehaviour {

	// Use this for initialization
    Vector3 lastPostion;
    bool overlap = false;

	void Start () {
        lastPostion = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private Vector3 screenPoint;
 private Vector3 offset;
 
 void OnMouseDown()
 {
     screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
     offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
 }
 
    void OnMouseDrag()
    {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            curPosition.y = transform.position.y;
            transform.position = curPosition;
            
            
    }
    void OnMouseUp()
    {
      
        if(overlap)
        {
            transform.position = lastPostion;
            overlap = false;
        }
    }
    void OnTriggerEnter()
    {
        print("trrr");
        overlap = true;
    }
    void OnTriggerExit()
    {
        print("enbnnn");
        overlap = false;

    }
   
}
