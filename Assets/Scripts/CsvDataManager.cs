using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum GameScore
{
    No,
    User,
    Score
}
public class CsvDataManager : MonoBehaviour
{
    [SerializeField]
    public TextAsset csvFile;

    char lineSeperator = '\n';

    public class CsvData
    {
        public int No;
        public string User;
        public int Score;
    }
    public Dictionary<string, CsvData> dataDictionary = new Dictionary<string, CsvData>();

    private void Start()
    {
        #region ������ �ְ� ���� �����
        //CsvData test = new CsvData();
        //test.No = 1;
        //test.User = "����";
        //test.Score = 98;
        //CsvData test1 = new CsvData();
        //test1.No = 2;
        //test1.User = "�ٴ�";
        //test1.Score = 100;
        //CsvData test2 = new CsvData();
        //test2.No = 3;
        //test2.User = "�䳢";
        //test2.Score = 92;

        //dataDictionary.Add("1", test);
        //dataDictionary.Add("2", test1);
        //dataDictionary.Add("3", test2);

        //CreateCSV();
        #endregion

        #region ������ Ȯ��
        CsvToDicionary();
        Debug.Log(GetObjData("1", GameScore.No) + GetObjData("1", GameScore.User) + GetObjData("1", GameScore.Score));
        Debug.Log(GetObjData("2", GameScore.No) + GetObjData("2", GameScore.User) + GetObjData("2", GameScore.Score));
        Debug.Log(GetObjData("3", GameScore.No) + GetObjData("3", GameScore.User) + GetObjData("3", GameScore.Score));
        #endregion
    }
    void CsvToDicionary()  //CSV�� Dicionary�� �ٲ�
    {
        string[] records = csvFile.text.Split(lineSeperator);

        int lineCount = 0;

        foreach (string record in records)
        {
            lineCount++;

            string[] fields = record.Split(',');

            if (string.IsNullOrEmpty(fields[0]))
            {
                break;
            }

            CsvData objData = new CsvData
            {
                No = int.Parse(fields[0]),     // Pars :�ڱ����� ���� ��ȯ
                User = fields[1],               //(ex) int.Parse(fields[0]) : fields[0]�� int������ �ٲ�
                Score = int.Parse(fields[2])
            };

            if (!dataDictionary.ContainsKey(fields[0]))
            {
                dataDictionary.Add(fields[0], objData);
                Debug.Log("Added: " + objData.No);
            }
            else
            {
                Debug.Log("duplicated object name exists");
            }
        }
    }

    public string GetObjData(string objName, GameScore dataName)
    {
        string data = "";

        if(!dataDictionary.ContainsKey(objName))
        {
            data = "None";
            return data;
        }
        
        switch (dataName)
        {
            case GameScore.No:
                data = dataDictionary[objName].No.ToString();
                break;
            case GameScore.User:
                data = dataDictionary[objName].User;
                break;
            case GameScore.Score:
                data = dataDictionary[objName].Score.ToString();
                break;
        }

        return data;
    }
    public void CreateCSV() //CSV���� �����
    {
        //Debug.Log(Application.dataPath + @"\my.csv")
        //Debug.Log(Application.dataPath + "\\my.csv") 
        using (StreamWriter writer = new StreamWriter(Application.dataPath + @"\my.csv")) //mobail = Application.persistentdataPath
        {
            foreach (var data in dataDictionary)
            {
                writer.WriteLine("{0},{1},{2}", data.Value.No, data.Value.User, data.Value.Score);
            }
        }
    }
}
