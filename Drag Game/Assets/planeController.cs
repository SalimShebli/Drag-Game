using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeController : MonoBehaviour {

    public List<Cube>[]Map;
	// Use this for initialization
	void Start () {
        Map = new List<Cube>[12];
        for (int i = 0; i < 10; i++)
            Map[i] = new List<Cube>();
        GenerateMapPositions();
	}
	void GenerateMapPositions()
    {
        float stx = -4.5f;
        float stz = -4.5f;
        for(int i=0;i<10;i++)
        {
            stz = -4.5f;
            for(int j=0;j<10;j++)
            {
                Map[i].Add(new Cube(stx, stz));
                Map[i][j].i = i;
                Map[i][j].j = j;
                stz += 1f;
            }
            stx += 1f;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
    public bool checkIFThereIsCube(Cube cube, Vector3 gg,GameObject me)
    {
        int ni = cube.i;
        int nj = cube.j;
        if (gg.x < cube.x)
        {
            ni -= 1;
        }
        else if (gg.x > cube.x)
        {
            ni += 1;
        }
        
        if (gg.z > cube.y)
        {
            nj += 1;
        }
        else if (gg.z < cube.y)
        {
            nj -= 1;
        }
        print(cube.i + "   " + cube.j + "  " + ni + "   " + nj);
        
        if (ni < 0 || nj < 0 || ni >= 10 || nj >= 10) return true;
        if (Map[ni][nj].Object != null && Map[ni][nj].Object != me) return true;
        if (Map[ni][cube.j].Object != null && Map[ni][nj].Object !=me) return true;
        if (Map[cube.i][nj].Object != null && Map[ni][nj].Object != me) return true;
        
        return false;
    }
    public Cube AskOfMyNewCube(Cube cube,GameObject gg)
    {
        int ni = cube.i;
        int nj = cube.j;
        if (gg.transform.position.x < cube.x - 0.5f)
        {
            ni -= 1;
        }
        else if (gg.transform.position.x > cube.x + 0.5f)
        {
            ni += 1;
        }
        if (gg.transform.position.z > cube.y + 0.5f)
        {
            nj += 1;
        }
        else if (gg.transform.position.z < cube.y - 0.5f)
        {
            nj -= 1;
        }
        Map[cube.i][cube.j].Object=null;
        Map[ni][nj].Object = gg;
        return Map[ni][nj];
    }
   
    public Cube GetCubeByIndex(int stI,int stJ,GameObject gg)
    {
        Map[stI][stJ].Object = gg;
        return Map[stI][stJ];
    }
}
public class Cube
    {
        public float x, y;
        public int i, j;
        public GameObject Object;
        public Cube()
        {
            x = 0f;
            y = 0f;
            Object = null;
        }
        public Cube(float X, float Y)
        {
            x = X;
            y = Y;
            i = 0; j = 0;
            Object = null;
        }
    }
