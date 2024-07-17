using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBundleLoader : MonoBehaviour
{
   /* public string bundleUrl = $"{Application.persistentDataPath}/download/{StaticClassData.lastGenerationName}"; // URL del tuo Asset Bundle
    public string assetName =  "model.obj"; // Nome dell'asset all'interno del bundle

    public void StartLoad() {
        StartCoroutine(DownloadAndLoadBundle(bundleUrl));
    }

    IEnumerator DownloadAndLoadBundle(string url)
    {
        // Scarica l'Asset Bundle dal server
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
            yield break;
        }

        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);

        if (bundle != null)
        {
            // Carica la mesh dall'Asset Bundle
            AssetBundleRequest assetRequest = bundle.LoadAssetAsync<Mesh>(assetName);
            yield return assetRequest;

            Mesh mesh = assetRequest.asset as Mesh;
            if (mesh != null)
            {
                GameObject obj = new GameObject("LoadedMeshObject");
                MeshFilter meshFilter = obj.AddComponent<MeshFilter>();
                meshFilter.mesh = mesh;
                obj.AddComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));
            }
            else
            {
                Debug.LogError("Failed to load mesh from AssetBundle");
            }

            // Scarica l'Asset Bundle dalla memoria una volta che non è più necessario
            bundle.Unload(false);
        }
    }*/
}
