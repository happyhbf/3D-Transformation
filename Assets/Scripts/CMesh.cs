using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMesh : MonoBehaviour
{
    public Vector3 Tran;
    public Vector3 Rot;

    public List<Point> Points;

    public Transform OldPoint;
    public Transform NewPoint;


    void Translate(float x, float y, float z)
    {
        foreach(Point pt in Points)
        {
            pt.X += x;
            pt.Y += y;
            pt.Z += z;
        }
    }

    void RotateX(float rotX)
    {
        float arc = rotX * Mathf.Deg2Rad;
        //foreach (Point pt in Points)
        //{
        //    //pt.X = ;
        //    pt.Y = pt.Y * Mathf.Cos(arc) - pt.Z * Mathf.Sin(arc);
        //    pt.Z = pt.Y * Mathf.Sin(arc) + pt.Z * Mathf.Cos(arc);
        //}

        float X = OldPoint.position.x * Mathf.Cos(arc) - OldPoint.position.y * Mathf.Sin(arc);
        float Y = OldPoint.position.x * Mathf.Sin(arc) + OldPoint.position.y * Mathf.Cos(arc);
        NewPoint.position = new Vector3(X, Y, OldPoint.position.z);
    }

    void RotateY(float rotY)
    {
        float arc = rotY * Mathf.Deg2Rad;

        float X = OldPoint.position.x * Mathf.Cos(arc) - OldPoint.position.z * Mathf.Sin(arc);
        float Z = OldPoint.position.x * Mathf.Sin(arc) + OldPoint.position.z * Mathf.Cos(arc);
        NewPoint.position = new Vector3(X, OldPoint.position.y, Z);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Translate(Tran.x, Tran.y, Tran.z);
        RotateX(Rot.x);
    }
}
