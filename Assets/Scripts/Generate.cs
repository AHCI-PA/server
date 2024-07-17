using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;
using System;

public class Generate : MonoBehaviour
{
    public TMP_Text query_text;
    public TMP_Text result;
    public GameObject player1, player2, player3, player4;

    public async void GenerateModel()
    {
        //Disabilitare schermata generate e mettere il bottone in stato d'attesa
        result.text = "Ready!!";
        string query = Uri.EscapeDataString(query_text.text);
        await StaticClassData.program.UnzipGetRequestAsync(query);
        StaticClassData.generationState = true;
        result.text = "OK!!";
        SetResult();
        //MAndare notifiche e appena si apre la scheramata generate mostra i video
    }

    private async void SetResult()
    {
        //VideoClip video1, video2, video3, video4;
        VideoPlayer videoP1, videoP2, videoP3, videoP4;
        string basePath = $"{Application.persistentDataPath}/download/{StaticClassData.lastGenerationName}/";

        videoP1 = player1.GetComponent<VideoPlayer>();
        videoP2 = player2.GetComponent<VideoPlayer>();
        videoP3 = player3.GetComponent<VideoPlayer>();
        videoP4 = player4.GetComponent<VideoPlayer>();
        videoP1.url = $"{basePath}0_model.mp4";
        videoP2.url = $"{basePath}1_model.mp4";
        videoP3.url = $"{basePath}2_model.mp4";
        videoP4.url = $"{basePath}3_model.mp4";
        videoP1.Play();
        videoP2.Play();
        videoP3.Play();
        videoP4.Play();
    }
}