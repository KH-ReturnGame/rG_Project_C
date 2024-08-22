using UnityEngine;

public class bend : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public float bendAmount = 1f;

    void Start()
    {
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        Vector3[] vertices = new Vector3[(width + 1) * (height + 1)];
        int[] triangles = new int[width * height * 6];

        for (int y = 0; y <= height; y++)
        {
            for (int x = 0; x <= width; x++)
            {
                float yOffset = Mathf.Sin(x * bendAmount);
                vertices[y * (width + 1) + x] = new Vector3(x, y + yOffset, 0);
            }
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int i0 = y * (width + 1) + x;
                int i1 = i0 + 1;
                int i2 = i0 + (width + 1);
                int i3 = i2 + 1;

                int t = (y * width + x) * 6;
                triangles[t + 0] = i0;
                triangles[t + 1] = i2;
                triangles[t + 2] = i1;
                triangles[t + 3] = i1;
                triangles[t + 4] = i2;
                triangles[t + 5] = i3;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
