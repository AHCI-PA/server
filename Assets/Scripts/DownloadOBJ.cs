using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DownloadOBJ : MonoBehaviour
{
    public GameObject gameObject;
    public TMP_Text numberObject;
    public async void GetOBJ()
    {
        await StaticClassData.program.SaveOBJGetRequestAsync(int.Parse(numberObject.text));
        gameObject.SetActive(false);
        string filePath = $"{Application.persistentDataPath}/download/{StaticClassData.lastGenerationName}/model.obj";
        Mesh mesh = ObjLoader.LoadFromPath(filePath);
        if (mesh != null)
        {
            GameObject meshObject = new GameObject("LoadedMesh");
            meshObject.transform.position = new Vector3(10, 1, 1);
            MeshFilter meshFilter = meshObject.AddComponent<MeshFilter>();
            meshFilter.mesh = mesh;
            meshObject.AddComponent<MeshRenderer>();
            ComponentClass.AddRigidBody(meshObject);
            ComponentClass.AddMeshCollider(meshObject);
            ComponentClass.AddGrabInteractable(meshObject);
        }
        else
        {
            Debug.LogError("Failed to load mesh from path: " + filePath);
        }
    }
}