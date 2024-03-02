using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

using UnityEngine;

public class TextFileTest : MonoBehaviour
{
    public string filePathTimeStamp;
    public string filePathTimeStamp2;

    void Start()
    {
        // D:\Unity\Project\My Practice ���⿡ �ִ� Assets ����
        filePathTimeStamp = Application.dataPath + "/../SwitchLog.txt";
        filePathTimeStamp2 = Application.dataPath + "/../SwitchLog2.txt";

        Debug.Log("�������ڸ��� Exit �α� �ϳ� �����");
        //CheckTimeStamp("AExit");
    }

    public void OnClickNum1()
    {
        Debug.Log("1���� Ŭ���Ͽ����ϴ�. Execute �α� �����");
        CheckTimeStamp("BExecute2");
    }

    public void OnClickNum3()
    {
        CheckTimeStamp("AExit2");
    }

    public void CheckTimeStamp(string flatformExitExecute)
    {
        using (StreamWriter writer = new StreamWriter(filePathTimeStamp, true))
        {
            DateTime timeStamp = DateTime.Now;
            writer.WriteLine($"[{timeStamp.ToString("yyyy-MM-dd  HH : mm : ss")}] " + flatformExitExecute);
        }
    }

    /// <summary>
    /// ///////////////////////////////////////////////////////////////// ���� ������ �� ����
    /// </summary>

    DateTime exitDateTime;
    DateTime executeDateTime;
    TimeSpan timeDifference;
    private string _logMessage;

    // �� ���� �ݰ� �ð� ���
    public void OnClickCalculateTimeStamp()
    {
        if (File.Exists(filePathTimeStamp))
        {
            List<string> exitTimes = new List<string>();
            List<string> executeTimes = new List<string>();

            string[] readAllLines = File.ReadAllLines(filePathTimeStamp);

            for (int i = 0; i < readAllLines.Length; i++)
            {
                string line = readAllLines[i];

                if (line.Contains("Exit"))
                {
                    // Exit �ð� ����
                    int startIndex = line.IndexOf('[') + 13; // '[' ������ ���� ���� �ε���
                    int endIndex = startIndex + 12; // ���� �κ��� ���� (yyyy-MM-dd HH : mm : ss)

                    if (endIndex <= line.Length)
                    {
                        string exitTime = line.Substring(startIndex, endIndex - startIndex);

                        // Exit �ð� ����Ʈ�� �߰�
                        exitTimes.Add(exitTime);

                        // ���� ���� ���� ���� �ִٸ� �� ���� Ȯ���Ͽ� "Execute"�� �ִٸ� �ش� �ؽ�Ʈ ���
                        if (i + 1 < readAllLines.Length)
                        {
                            string nextLine = readAllLines[i + 1];

                            if (nextLine.Contains("Execute"))
                            {
                                // ���⼭ executeTime�� nextLine���� �����ؾ� �մϴ�.
                                int executeStartIndex = nextLine.IndexOf('[') + 13;
                                int executeEndIndex = executeStartIndex + 12;

                                if (executeEndIndex <= nextLine.Length)
                                {
                                    string executeTime = nextLine.Substring(executeStartIndex, executeEndIndex - executeStartIndex);
                                    executeTimes.Add(executeTime);

                                    Debug.Log(exitTime + " Exit++�ð�");
                                    Debug.Log(executeTime + " Execute++�ð�");

                                    for (int j = 0; j < exitTimes.Count && j < executeTimes.Count; j++)
                                    {
                                        exitDateTime = DateTime.ParseExact(exitTimes[j], "HH : mm : ss", CultureInfo.InvariantCulture);
                                        executeDateTime = DateTime.ParseExact(executeTimes[j], "HH : mm : ss", CultureInfo.InvariantCulture);
                                        timeDifference = executeDateTime - exitDateTime;
                                    }

                                    _logMessage = $"Exit    �ð�: {exitDateTime}" +
                                        $", \nExecute �ð�: {executeDateTime}" +
                                        $", \n����: {timeDifference.TotalSeconds} ��" +
                                        $" \n==================================";

                                    using (StreamWriter writer = new StreamWriter("SwitchLog2.txt", true))
                                    {
                                        writer.WriteLine(_logMessage);
                                    }
                                    //Debug.Log($"����: {timeDifference.TotalSeconds} ��");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}