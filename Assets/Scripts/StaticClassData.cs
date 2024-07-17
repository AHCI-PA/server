using System;
using System.Net.Http;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using UnityEngine;
public static class StaticClassData
{
    public static Program program;
    public static bool generationState;
    public static string lastGenerationName;

    public static void CreatePrograme(string URL, string cli_id)
    {
        program = new Program(URL, cli_id);
    }
}

public class Program
{

    private HttpClient program_client;
    private string program_URL;
    private string cli_id;

    public Program(string URL, string cli_id)
    {
        this.program_client = new HttpClient();
        this.program_URL = URL;
        this.cli_id = cli_id;
    }
    // This method is useful only to get if the server is up, does a get to the root
    public async Task<string> GetRequestAsync()
    {
        HttpResponseMessage response = await this.program_client.GetAsync(this.program_URL);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> PostRequestAsync()
    {
        Debug.Log("Ciao");
        string postURL = $"{this.program_URL}/auth?cli_id={this.cli_id}";
        HttpResponseMessage response = await this.program_client.PostAsync(postURL, null);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task UnzipGetRequestAsync(string query)
    {
        StaticClassData.lastGenerationName = query;
        string zipFilePath = $"{Application.persistentDataPath}/download/{query}/";
        if (!Directory.Exists(zipFilePath))
        {
            Directory.CreateDirectory(zipFilePath);
        }
        string getURL = $"{this.program_URL}/query?cli_id={this.cli_id}&query={query}&tentatives=4"; ;
        HttpResponseMessage responseMessage = await this.program_client.GetAsync(getURL);
        responseMessage.EnsureSuccessStatusCode();
        using (Stream zipStream = await responseMessage.Content.ReadAsStreamAsync())
        using (ZipArchive zip = new ZipArchive(zipStream))
        {
            zip.ExtractToDirectory(zipFilePath);
        }
        Console.WriteLine("UNZIP-DONE");
    }

    public async Task SaveOBJGetRequestAsync(int obj_num)
    {
        // Ensure the final path includes "object.obj"

        string objFilePath = $"{Application.persistentDataPath}/download/{StaticClassData.lastGenerationName}/";
        string downloadUrl = $"{this.program_URL}/download?cli_id={this.cli_id}&object={obj_num}&query={StaticClassData.lastGenerationName}";
        if (!Directory.Exists(objFilePath))
        {
            Directory.CreateDirectory(objFilePath);
        }
        objFilePath = $"{objFilePath}model.obj";

        HttpResponseMessage responseMessage = await this.program_client.GetAsync(downloadUrl);
        responseMessage.EnsureSuccessStatusCode();

        using (Stream objStream = await responseMessage.Content.ReadAsStreamAsync())
        using (FileStream fileStream = new FileStream(objFilePath, FileMode.CreateNew, FileAccess.Write))
        {
            await objStream.CopyToAsync(fileStream);
        }
    }


    /*static async Task Main(string[] args){
        string url = "https://7034-194-119-214-242.ngrok-free.app/";
        Program program = new Program(url);

        // Example usage of GetRequestAsync
        string result = await program.GetRequestAsync();
        Console.WriteLine(result);
        Console.WriteLine("Changing to another method: POST");
        Thread.Sleep(1000);

        // Example usage of PostRequestAsync
        string cli_id = "provacsharp1";
        string post_result = await program.PostRequestAsync(cli_id);
        Console.WriteLine("Changing to another method: QUERY GENERATION");
        Thread.Sleep(1000);

        // Example usage of UnzipPostRequestAsync
        string query = Uri.EscapeDataString("una moto rossa");
        await program.UnzipGetRequestAsync(cli_id, query);
        Console.WriteLine("Changing to another method: POST");
        Thread.Sleep(1000);

        // Example usage of SaveOBJPostRequestAsync
        int obj_num = 2;
        await program.SaveOBJGetRequestAsync(cli_id, query, obj_num);
        Thread.Sleep(1000);
    }*/
}