using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDragController : MonoBehaviour {

	// Use this for initialization
    Vector3 lastPostion;
    bool overlap = false;
    public planeController plane;
    Cube curCube;
    public int startI, startJ;
	void Start () {
        lastPostion = transform.position;
        StartCoroutine(SetInfo());
	}
	IEnumerator SetInfo()
    {
        yield return new WaitForSeconds(0.2f);
        curCube = plane.GetCubeByIndex(startI, startJ,gameObject);
        
        OnMouseUp();
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
     if (!plane.checkIFThereIsCube(curCube, curPosition,gameObject))
     {
         transform.position = curPosition;
      //   print("st   "+curCube.i + "      " + curCube.j);
         curCube= plane.AskOfMyNewCube(curCube,gameObject);
        // print(curCube.i + "      " + curCube.j);
     }


 }
    void OnMouseUp()
    {
        
        Vector3 postion = gameObject.transform.position;
        postion.x = curCube.x;
        postion.z = curCube.y;
        gameObject.transform.position = postion;
        //curCube.Object = gameObject;
        
    }
    
}
