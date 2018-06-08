using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private float mX;
    private float mY;
    private float mZ;

    private void Awake()
    {
        mX = transform.position.x;
        mY = transform.position.y;
        mZ = transform.position.z;
    }

    public float X
    {
        set
        {
            mX = value;
        }
        get
        {
            return mX;
        }
    }

    public float Y
    {
        set
        {
            mY = value;
        }
        get
        {
            return mY;
        }
    }

    public float Z
    {
        set
        {
            mZ = value;
        }
        get
        {
            return mZ;
        }
    }


    public Transform PT;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        PT.position = new Vector3(X, Y, Z);

    }
}
