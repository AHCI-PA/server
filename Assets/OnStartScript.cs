
using System.Collections;
using UnityEngine;
using Siccity.GLTFUtility;
using UnityEngine.Networking;
using System.IO;

public class OnStartScript : MonoBehaviour
{

    public string meshUrl = "https://4aea-194-119-214-222.ngrok-free.app/help";
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private Vector3 originalScale;
    private Material originalMaterial;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        originalScale = transform.localScale;
        originalMaterial = meshRenderer.material;
        
        ReplaceMesh();

    }

    public void ReplaceMesh()
    {
        StartCoroutine(DownloadAndReplaceMesh());
    }

    IEnumerator DownloadAndReplaceMesh()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(meshUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Errore nel download del file: " + www.error);
            }
            else
            {
                byte[] fbxData = www.downloadHandler.data;
                string tempPath = Path.Combine(Application.temporaryCachePath, "temp.fbx");
                File.WriteAllBytes(tempPath, fbxData);

                GameObject importedObject = Importer.LoadFromFile(tempPath);

                if (importedObject != null)
                {
                    MeshFilter importedMeshFilter = importedObject.GetComponent<MeshFilter>();
                    if (importedMeshFilter != null)
                    {
                        // Sostituisci la mesh
                        Mesh oldMesh = meshFilter.sharedMesh;
                        meshFilter.sharedMesh = importedMeshFilter.sharedMesh;

                        // Adatta la scala
                        AdjustScale();

                        // Mantieni il materiale originale
                        meshRenderer.material = originalMaterial;

                        // Pulisci
                        Destroy(oldMesh);
                        Destroy(importedObject);
                    }
                    else
                    {
                        Debug.LogError("MeshFilter non trovato nell'oggetto importato");
                    }
                }
                else
                {
                    Debug.LogError("Impossibile importare l'oggetto");
                }

                // Rimuovi il file temporaneo
                File.Delete(tempPath);
            }
        }
    }

    void AdjustScale()
    {
        Bounds newBounds = meshFilter.sharedMesh.bounds;
        Vector3 newSize = newBounds.size;
        Vector3 originalSize = GetComponent<Renderer>().bounds.size;

        float scaleX = originalSize.x / newSize.x;
        float scaleY = originalSize.y / newSize.y;
        float scaleZ = originalSize.z / newSize.z;

        transform.localScale = new Vector3(
            originalScale.x * scaleX,
            originalScale.y * scaleY,
            originalScale.z * scaleZ
        );
    }
}
/*
public async void GetOBJ()
    {
        TMPro_Text debugTest = "";
        await StaticClassData.program.SaveOBJGetRequestAsync(0);
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
        MeshRenderer renderer = meshObject1.AddComponent<MeshRenderer>();
        renderer.material = (Material)Resources.Load("Arrows");
        ComponentClass.AddRigidBody(meshObject1);
        ComponentClass.AddRigidBody(meshObject1);
        meshObject1.SetActive(true);
        //ComponentClass.AddMeshCollider(meshObject);
        //debugTest.text = "Success 6";
        //ComponentClass.AddXRGrabInteractable(meshObject);
        //debugTest.text = "Success 7";
        //
        //debugTest.text = "Success";

 
    // Update is called once per frame
   
void Update()
    {
        
    }
}
*/