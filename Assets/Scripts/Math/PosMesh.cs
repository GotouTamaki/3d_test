using UnityEngine;

public class PosMesh : MonoBehaviour
{
    [SerializeField] private Material _material;
    void Start()
    {
        var meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = _material;
        var mesh = new Mesh();
        mesh.SetVertices(new Vector3[] { new(0f, 0f, 9f), new(5f, 0f, -7f), new(-3f, 0f, -5f) });
        mesh.SetTriangles(new int[] { 0, 1, 2 }, 0);
        var filter = gameObject.AddComponent<MeshFilter>();
        //var filter = gameObject.GetComponent<MeshFilter>();
        filter.sharedMesh = mesh;
    }
}