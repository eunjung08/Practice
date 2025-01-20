using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonDataManager : MonoBehaviour
{
    [Tooltip("�����ϱ� ���ϴ� ���� �̸�(.json ����")]
    public string fileName = "JsonSample";

    [System.Serializable]

    public class Data
    {
        public int No;
        public string User;
        public int Score;
    }
    
    public Data data;

    void Start()
    {
        //data = new Data();
        //data.No = 1;
        //data.User = "����";
        //data.Score = 90;

        //SaveDataToJson();

        LoadDataFromJsom();

        Debug.Log(data.No + data.User + data.Score);
    }

    void SaveDataToJson()
    {
        string jsonData = "";

        jsonData = JsonUtility.ToJson(data, true);

        File.WriteAllText(Application.dataPath + @"\" + fileName, jsonData);
    }

    void LoadDataFromJsom()
    {
        string jsonData = "";
        jsonData = File.ReadAllText(Application.dataPath + @"\" +fileName);
        data =JsonUtility.FromJson<Data>(jsonData);
    }
}
