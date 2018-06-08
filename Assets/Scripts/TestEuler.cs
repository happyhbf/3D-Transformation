using UnityEngine;

[ExecuteInEditMode]
public class TestEuler : MonoBehaviour
{
    public Vector3 Euler;

    public Vector3 OrgPosOfA;
    public Vector3 OrgPosOfB;
    public Vector3 OrgPosOfC;

    public Transform TransA;
    public Transform TransB;
    public Transform TransC;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TransA.position = Rotate(OrgPosOfA, Euler) + transform.position;
        TransB.position = Rotate(OrgPosOfB, Euler) + transform.position;
        TransC.position = Rotate(OrgPosOfC, Euler) + transform.position;
    }

    Vector3 Rotate(Vector3 pos, Vector3 euler)
    {
        
        pos = RotateX(pos, euler.x * Mathf.Deg2Rad);
        
        pos = RotateZ(pos, euler.z * Mathf.Deg2Rad);
        pos = RotateY(pos, euler.y * Mathf.Deg2Rad);

        return pos;
    }

    Vector3 RotateX(Vector3 pos, float r)
    {
        Vector3 newPos = pos;

        float cos = Mathf.Cos(r);
        float sin = Mathf.Sin(r);
        newPos.y = pos.y * cos - pos.z * sin;
        newPos.z = pos.y * sin + pos.z * cos;

        return newPos;
    }

    Vector3 RotateY(Vector3 pos, float r)
    {
        Vector3 newPos = pos;

        float cos = Mathf.Cos(r);
        float sin = Mathf.Sin(r);
        newPos.x = pos.x * cos - pos.z * sin;
        newPos.z = pos.x * sin + pos.z * cos;

        return newPos;
    }

    Vector3 RotateZ(Vector3 pos, float r)
    {
        Vector3 newPos = pos;

        float cos = Mathf.Cos(r);
        float sin = Mathf.Sin(r);
        newPos.x = pos.x * cos - pos.y * sin;
        newPos.y = pos.x * sin + pos.y * cos;

        return newPos;
    }

    void OnDrawGizmos()
    {
        //坐标轴
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.forward);

        //旋转后的点
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, TransA.position);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, TransB.position);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, TransC.position);
    }
}
