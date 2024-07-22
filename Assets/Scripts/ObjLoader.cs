using UnityEngine;
using System.Collections.Generic;
using System.IO;
<<<<<<< HEAD
using System;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.Android;
public static class ObjLoader {
    public async static Task<Mesh> LoadFromPath(string filePath, TMP_Text debugText)
    {
        if (!File.Exists(filePath)) {
            debugText.text = $"File not found: {filePath}";
            return null;
        }
        string objData = string.Empty;
        try {
            objData = File.ReadAllText(filePath);
        }
        catch(Exception e){
            debugText.text = "Exception: " + e.ToString();
        }
        return await Load(objData, debugText);
    }

    
    public async static Task<Mesh> Load(string objData, TMP_Text debugText)
    {
        var mesh = new Mesh();
        int numDebug = 0;
        var vertices = new List<Vector3>();
        var triangles = new List<int>();
        var normals = new List<Vector3>();

=======

public static class ObjLoader
{
    public static Mesh LoadFromPath(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError($"File not found: {filePath}");
            return null;
        }

        string objData = File.ReadAllText(filePath);
        return Load(objData);
    }

    public static Mesh Load(string objData)
    {
        var mesh = new Mesh();

        var vertices = new List<Vector3>();
        var triangles = new List<int>();
>>>>>>> 3e21fa81926153c7bd4ba55b45b8c7c422c2d527

        using (var reader = new StringReader(objData))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("v "))
                {
<<<<<<< HEAD
                    numDebug++;
                    var vertex = ParseVertex(line);
                    debugText.text = numDebug.ToString();
                    vertices.Add(vertex);
                }
                else if (line.StartsWith("vn ")) {
                    var vertex = ParseVertex(line);
                    normals.Add(vertex);
                }
=======
                    var vertex = ParseVertex(line);
                    vertices.Add(vertex);
                }
>>>>>>> 3e21fa81926153c7bd4ba55b45b8c7c422c2d527
                else if (line.StartsWith("f "))
                {
                    var faceIndices = ParseFace(line);
                    triangles.AddRange(faceIndices);
                }
<<<<<<< HEAD
                /*if(numDebug % 250 == 0) {
                    
                }
                else if(numDebug < 250)
                    //debugText.text = "Step " + numDebug + " completato:  " + line; */
            }
        }
       
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.normals = normals.ToArray();
        mesh.RecalculateBounds(); 
        //debugText.text = "Success";
        return mesh;
    }
    
    
    public static Mesh LoadStream(string filePath, TMP_Text debugText)
    {
        var mesh = new Mesh();

        var vertices = new List<Vector3>();
        var triangles = new List<int>();
        var normals = new List<Vector3>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            debugText.text = "Inizion stream";
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("v "))
                {
                    var vertex = ParseVertex(line);
                    vertices.Add(vertex);
                }
                else if (line.StartsWith("vn ")) {
                    var vertex = ParseVertex(line);
                    normals.Add(vertex);
                }
                else if (line.StartsWith("f "))
                {
                    var faceIndices = ParseFace(line);
                    triangles.AddRange(faceIndices);
                }

                debugText.text = line;
            }
        }
        debugText.text = "Fine stream";
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.normals = normals.ToArray();
        mesh.RecalculateBounds();
        return mesh;
    }
    
    
=======
            }
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        return mesh;
    }

>>>>>>> 3e21fa81926153c7bd4ba55b45b8c7c422c2d527
    private static Vector3 ParseVertex(string line)
    {
        var parts = line.Split(' ');
        return new Vector3(
            float.Parse(parts[1]),
            float.Parse(parts[2]),
            float.Parse(parts[3])
        );
    }

    private static int[] ParseFace(string line)
    {
        var parts = line.Split(' ');
        return new int[]
        {
            int.Parse(parts[1].Split('/')[0]) - 1,
            int.Parse(parts[2].Split('/')[0]) - 1,
            int.Parse(parts[3].Split('/')[0]) - 1
        };
    }
}