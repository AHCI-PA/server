using UnityEngine;
using System.Collections.Generic;
using System.IO;

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

        using (var reader = new StringReader(objData))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("v "))
                {
                    var vertex = ParseVertex(line);
                    vertices.Add(vertex);
                }
                else if (line.StartsWith("f "))
                {
                    var faceIndices = ParseFace(line);
                    triangles.AddRange(faceIndices);
                }
            }
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        return mesh;
    }

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