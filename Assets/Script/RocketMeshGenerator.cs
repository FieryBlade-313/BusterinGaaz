using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMeshGenerator : MonoBehaviour
{  
    Mesh mesh;

    Parameters param;

    PolygonCollider2D polyCollider;

    Vector3[] vertices;
    int[] traingles;
    void Start()
    {
        mesh = new Mesh();
        polyCollider = gameObject.AddComponent<PolygonCollider2D>();
        polyCollider.pathCount = 4;
        GetComponent<MeshFilter>().mesh = mesh;

        param = GetComponent<Parameters>();

        CalculateMeshInfo();

    }

    public void CalculateMeshInfo()
    {
        Vector2 dir = param.getDirVector();

        vertices = new Vector3[]
        {
            /*new Vector3(0, param.getAreaCenter()/2, 0),
            new Vector3(0, 2 * param.getAreaConcentric(), 0),
            new Vector3(param.getLength(), 2 * param.getAreaConcentric(), 0),
            new Vector3(param.getTotalLength(), param.getAreaConcentric(), 0),
            new Vector3(param.getTotalLength(), param.getAreaCenter()/2, 0),
            new Vector3(0, 2 * param.getAreaConcentric() + param.getAreaOther(), 0),
            new Vector3(0, 2 * param.getAreaConcentric() + param.getAreaOther() + param.getWidth(), 0),
            new Vector3(param.getTotalLength(), 2 * param.getAreaConcentric() + param.getAreaOther() + param.getWidth(), 0),
            new Vector3(param.getTotalLength(), param.getAreaConcentric() + param.getAreaOther(), 0),
            new Vector3(param.getLength(), 2 * param.getAreaConcentric() + param.getAreaOther(), 0),
            new Vector3(0, -(param.getAreaCenter()/2), 0),
            new Vector3(0, -(2 * param.getAreaConcentric()), 0),
            new Vector3(param.getLength(), -(2 * param.getAreaConcentric()), 0),
            new Vector3(param.getTotalLength(), -(param.getAreaConcentric()), 0),
            new Vector3(param.getTotalLength(), -(param.getAreaCenter()/2), 0),
            new Vector3(0, -(2 * param.getAreaConcentric() + param.getAreaOther()), 0),
            new Vector3(0, -(2 * param.getAreaConcentric() + param.getAreaOther() + param.getWidth()), 0),
            new Vector3(param.getTotalLength(), -(2 * param.getAreaConcentric() + param.getAreaOther() + param.getWidth()), 0),
            new Vector3(param.getTotalLength(), -(param.getAreaConcentric() + param.getAreaOther()), 0),
            new Vector3(param.getLength(), -(2 * param.getAreaConcentric() + param.getAreaOther()), 0)*/
            new Vector3(0, param.getAreaCenter()/2, 0),
            new Vector3(0, param.getAreaCenter()/2 + param.getAreaConcentric() + dir.y, 0),
            new Vector3(param.getLength()-dir.x, param.getAreaCenter()/2 + param.getAreaConcentric() + dir.y, 0),
            new Vector3(param.getLength(), param.getAreaCenter()/2 + param.getAreaConcentric(), 0),
            new Vector3(param.getLength(), param.getAreaCenter()/2, 0),
            new Vector3(0, param.getAreaCenter()/2 + param.getAreaConcentric() + dir.y + param.getAreaOther(), 0),
            new Vector3(0, param.getAreaCenter()/2 + param.getAreaConcentric() + dir.y + param.getAreaOther() + param.getWidth(), 0),
            new Vector3(param.getLength() + param.getAreaOther() * dir.y + param.getExtraLength(), param.getAreaCenter()/2 + param.getAreaConcentric() + dir.y + param.getAreaOther() + param.getWidth(), 0),
            new Vector3(param.getLength() + param.getAreaOther() * dir.y, param.getAreaCenter()/2 + param.getAreaConcentric() + param.getAreaOther() * dir.x, 0),
            new Vector3(param.getLength() - dir.x + param.getAreaOther() * dir.y, param.getAreaCenter()/2 + param.getAreaConcentric() + dir.y + param.getAreaOther(), 0),

            new Vector3(0, -param.getAreaCenter()/2, 0),
            new Vector3(0, -(param.getAreaCenter()/2 + param.getAreaConcentric() + dir.y), 0),
            new Vector3(param.getLength()-dir.x, -(param.getAreaCenter()/2 + param.getAreaConcentric() + dir.y), 0),
            new Vector3(param.getLength(), -(param.getAreaCenter()/2 + param.getAreaConcentric()), 0),
            new Vector3(param.getLength(), -(param.getAreaCenter()/2), 0),
            new Vector3(0, -(param.getAreaCenter()/2 + param.getAreaConcentric() + dir.y + param.getAreaOther()), 0),
            new Vector3(0, -(param.getAreaCenter()/2 + param.getAreaConcentric() + dir.y + param.getAreaOther() + param.getWidth()), 0),
            new Vector3(param.getLength() + param.getAreaOther() * dir.y + param.getExtraLength(), -(param.getAreaCenter()/2 + param.getAreaConcentric() + dir.y + param.getAreaOther() + param.getWidth()), 0),
            new Vector3(param.getLength() + param.getAreaOther() * dir.y, -(param.getAreaCenter()/2 + param.getAreaConcentric() + param.getAreaOther() * dir.x), 0),
            new Vector3(param.getLength() - dir.x + param.getAreaOther() * dir.y, -(param.getAreaCenter()/2 + param.getAreaConcentric() + dir.y + param.getAreaOther()), 0),

        };

        traingles = new int[]
        {
            0,1,2,
            2,3,4,
            2,4,0,
            5,6,9,
            6,7,9,
            7,8,9,
            10,12,11,
            12,14,13,
            12,10,14,
            15,19,16,
            16,19,17,
            17,19,18,
        };

        UpdateMeshInfo();
    }

    void UpdateMeshInfo()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = traingles;

        UpdateColliderInfo();
    }

    public void UpdateColliderInfo()
    {
        Vector2[] path1 = { vertices[0], vertices[1], vertices[2], vertices[3], vertices[4] };
        Vector2[] path2 = { vertices[5], vertices[6], vertices[7], vertices[8], vertices[9] };
        Vector2[] path3 = { vertices[10], vertices[11], vertices[12], vertices[13], vertices[14] };
        Vector2[] path4 = { vertices[15], vertices[16], vertices[17], vertices[18], vertices[19] };
        polyCollider.SetPath(0, path1);
        polyCollider.SetPath(1, path2);
        polyCollider.SetPath(2, path3);
        polyCollider.SetPath(3, path4);

    }
}
