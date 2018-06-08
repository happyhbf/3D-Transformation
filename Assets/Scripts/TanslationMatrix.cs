using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanslationMatrix : MonoBehaviour {

    public Transform[] OldPoints;
    public Transform[] NewPoints;

    public float TranslateX;
    public float TranslateY;
    public float TranslateZ;

    // Update is called once per frame
    void Update()
    {
        MatrixTranslate();
    }

    void MatrixTranslate()
    {
        Matrix4x4 mat = new Matrix4x4(new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(TranslateX, TranslateY, TranslateZ, 1));

        for (int i = 0; i < OldPoints.Length; i++)
        {
            Transform oldPT = OldPoints[i];
            Transform newPT = NewPoints[i];
            Vector3 position = oldPT.position;
            Vector3 newPosition = MatrixMultiplyPoint(mat, new Vector4(position.x, position.y, position.z, 1));
            newPT.position = newPosition;
        }
    }

    Vector4 MatrixMultiplyPoint(Matrix4x4 mat, Vector4 pt)
    {
        Vector4 newPt = Vector4.zero;
        newPt.x = mat.m00 * pt.x + mat.m01 * pt.y + mat.m02 * pt.z + pt.w * mat.m03;
        newPt.y = mat.m10 * pt.x + mat.m11 * pt.y + mat.m12 * pt.z + pt.w * mat.m13;
        newPt.z = mat.m20 * pt.x + mat.m21 * pt.y + mat.m22 * pt.z + pt.w * mat.m23;
        newPt.w = mat.m30 * pt.x + mat.m31 * pt.y + mat.m32 * pt.z + pt.w * mat.m33;
        return newPt;
    }
}
