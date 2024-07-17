using System.Collections;
using System.Collections.Generic;
using System.IO;
using HuggingFace.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeechRecognitionTest : MonoBehaviour
{
    [SerializeField]
    private Button recordButton;

    [SerializeField]
    private TextMeshProUGUI text;

    private AudioClip clip;
    private byte[] bytes;
    private bool recording;

    public void ClickButtonRecording()
    {
        if (recording)
            StopRecording();
        else
            StartRecording();
    }

    private void StartRecording()
    {
        clip = Microphone.Start(null, false, 60, 44100);
        recording = true;
    }

    private void StopRecording()
    {
        var position = Microphone.GetPosition(null);
        Microphone.End(null);
        var samples = new float[position * clip.channels];
        clip.GetData(samples, 0);
        bytes = EncodeAsWAV(samples, clip.frequency, clip.channels);
        recording = false;
        SendRecording();
    }

    private void SendRecording()
    {
        text.color = Color.yellow;
        text.text = "Sending...";
        HuggingFaceAPI.AutomaticSpeechRecognition(bytes, response => {
            text.color = Color.white;
            text.text = response;
        }, error => {
            text.color = Color.red;
            text.text = error;
        });
    }

    private byte[] EncodeAsWAV(float[] samples, int frequency, int channels)
    {
        using (var memoryStream = new MemoryStream(44 + samples.Length * 2))
        {
            using (var writer = new BinaryWriter(memoryStream))
            {
                writer.Write("RIFF".ToCharArray());
                writer.Write(36 + samples.Length * 2);
                writer.Write("WAVE".ToCharArray());
                writer.Write("fmt ".ToCharArray());
                writer.Write(16);
                writer.Write((ushort)1);
                writer.Write((ushort)channels);
                writer.Write(frequency);
                writer.Write(frequency * channels * 2);
                writer.Write((ushort)(channels * 2));
                writer.Write((ushort)16);
                writer.Write("data".ToCharArray());
                writer.Write(samples.Length * 2);

                foreach (var sample in samples)
                {
                    writer.Write((short)(sample * short.MaxValue));
                }
            }
            return memoryStream.ToArray();
        }
    }
}