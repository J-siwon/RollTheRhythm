using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro.Examples; // File IO

public class DataManager : MonoBehaviour
{

    public string fileName = "Note1_1.json";
    private NoteChart currentChart;

    public static DataManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            //SceneManager.
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        LoadChartFromJson(fileName);
        if (currentChart != null)
        {
            Debug.Log("Song: " + currentChart.songName);
            Debug.Log("BPM: " + currentChart.bpm);
        }else
        {
            Debug.Log("load failed");
        }
    }

    public NoteChart LoadChartFromJson(string jsonFileName)
    {
        // ��: Application.streamingAssetsPath/Resources/ ...
        // Ȥ�� Assets/Resources ��� �� ������Ʈ ������ �°� ����
        string path = Path.Combine(Application.dataPath, "Sources", "NoteSource",  jsonFileName); //json ���� �б�

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            currentChart = JsonUtility.FromJson<NoteChart>(json);
        }
        else
        {
            Debug.LogError("File not found: " + path);
        }

        return currentChart;
    }

    void SaveChartToJson(NoteChart chart, string jsonFileName)
    {
        string json = JsonUtility.ToJson(chart, true); // prettyPrint = true
        string path = Path.Combine(Application.dataPath, jsonFileName);
        File.WriteAllText(path, json);
        Debug.Log("Saved chart to " + path);
    }
}
