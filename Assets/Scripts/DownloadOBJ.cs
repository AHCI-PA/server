using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class DownloadOBJ : MonoBehaviour
{
    public GameObject gameObject1, gameObject2;
    public GameObject gameObject;
    public TMP_Text numberObject;
    public TMP_Text debugTest;
    public async void GetOBJ()
    {
        gameObject.SetActive(false);
        await StaticClassData.program.SaveOBJGetRequestAsync(int.Parse(numberObject.text));
        debugTest.gameObject.SetActive(true);
        string filePath = $"{Application.persistentDataPath}/download/{StaticClassData.lastGenerationName}/model.obj";
        Mesh mesh = await ObjLoader.LoadFromPath(filePath, debugTest);
        GameObject meshObject = new GameObject("LoadedObject");
        meshObject.transform.position = new Vector3(0f, 1f, 1f);
        MeshFilter meshFilter = meshObject.AddComponent<MeshFilter>();
        //meshFilter.mesh = await CreateCubeMesh();
        GameObject meshObject1 = new GameObject("LoadedObject1");
        meshObject1.transform.position = new Vector3(10f, 1f, 1f);
        MeshFilter meshFilter1 = meshObject1.AddComponent<MeshFilter>();
        meshFilter1.mesh = mesh;
        debugTest.text = "Success 3";
        MeshRenderer renderer = meshObject1.AddComponent<MeshRenderer>();
        renderer.material = (Material)Resources.Load("Arrows");
        debugTest.text = "Success 4";
        ComponentClass.AddRigidBody(meshObject1);
        debugTest.text = "Success 5";
        ComponentClass.AddRigidBody(meshObject1);
        debugTest.text = "Success 5";
        meshObject1.SetActive(true);
        //ComponentClass.AddMeshCollider(meshObject);
        //debugTest.text = "Success 6";*/
        //ComponentClass.AddXRGrabInteractable(meshObject);
        //debugTest.text = "Success 7";
        //
        //debugTest.text = "Success";

    }


    private async Task<Mesh> CreateCubeMesh()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = {
            // Front face
            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f),
            // Back face
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, -0.5f)
        };

        int[] triangles = {
            // Front face
            0, 2, 1,
            0, 3, 2,
            // Top face
            2, 3, 7,
            2, 7, 6,
            // Back face
            5, 7, 4,
            5, 6, 7,
            // Bottom face
            0, 1, 5,
            0, 5, 4,
            // Left face
            0, 4, 7,
            0, 7, 3,
            // Right face
            1, 2, 6,
            1, 6, 5
        };

        Vector3[] normals = {
            // Normals for each vertex
            Vector3.forward,
            Vector3.forward,
            Vector3.forward,
            Vector3.forward,
            Vector3.back,
            Vector3.back,
            Vector3.back,
            Vector3.back
        };

        Vector2[] uv = {
            // UV coordinates
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1)
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        return mesh;
    }
    /*
    private async Task<Mesh> SimplifyMesh(Mesh originalMesh, float ratio)
    {
        if (ratio <= 0.0f || ratio >= 1.0f)
        {
            Debug.LogWarning("Invalid simplification ratio. It must be between 0 and 1.");
            return originalMesh;
        }

        // Crea un MeshSimplifier con la mesh originale
        //UnityMeshSimplifier.MeshSimplifier meshSimplifier = new UnityMeshSimplifier.MeshSimplifier(originalMesh);

        // Semplifica la mesh al rapporto desiderato
        //meshSimplifier.SimplifyMesh(ratio);

        // Restituisci la mesh semplificata
        return meshSimplifier.ToMesh();
    }
}*/
}