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
        // D:\Unity\Project\My Practice 여기에 있다 Assets 전에
        filePathTimeStamp = Application.dataPath + "/../SwitchLog.txt";
        filePathTimeStamp2 = Application.dataPath + "/../SwitchLog2.txt";

        Debug.Log("시작하자마자 Exit 로그 하나 찍어줌");
        //CheckTimeStamp("AExit");
    }

    public void OnClickNum1()
    {
        Debug.Log("1번을 클릭하였습니다. Execute 로그 찍어줌");
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
    /// ///////////////////////////////////////////////////////////////// 여기 위까진 잘 찍힘
    /// </summary>

    DateTime exitDateTime;
    DateTime executeDateTime;
    TimeSpan timeDifference;
    private string _logMessage;

    // 앱 열고 닫고 시간 계산
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
                    // Exit 시간 추출
                    int startIndex = line.IndexOf('[') + 13; // '[' 다음의 숫자 시작 인덱스
                    int endIndex = startIndex + 12; // 숫자 부분의 길이 (yyyy-MM-dd HH : mm : ss)

                    if (endIndex <= line.Length)
                    {
                        string exitTime = line.Substring(startIndex, endIndex - startIndex);

                        // Exit 시간 리스트에 추가
                        exitTimes.Add(exitTime);

                        // 현재 줄의 다음 줄이 있다면 그 줄을 확인하여 "Execute"가 있다면 해당 텍스트 출력
                        if (i + 1 < readAllLines.Length)
                        {
                            string nextLine = readAllLines[i + 1];

                            if (nextLine.Contains("Execute"))
                            {
                                // 여기서 executeTime을 nextLine에서 추출해야 합니다.
                                int executeStartIndex = nextLine.IndexOf('[') + 13;
                                int executeEndIndex = executeStartIndex + 12;

                                if (executeEndIndex <= nextLine.Length)
                                {
                                    string executeTime = nextLine.Substring(executeStartIndex, executeEndIndex - executeStartIndex);
                                    executeTimes.Add(executeTime);

                                    Debug.Log(exitTime + " Exit++시간");
                                    Debug.Log(executeTime + " Execute++시간");

                                    for (int j = 0; j < exitTimes.Count && j < executeTimes.Count; j++)
                                    {
                                        exitDateTime = DateTime.ParseExact(exitTimes[j], "HH : mm : ss", CultureInfo.InvariantCulture);
                                        executeDateTime = DateTime.ParseExact(executeTimes[j], "HH : mm : ss", CultureInfo.InvariantCulture);
                                        timeDifference = executeDateTime - exitDateTime;
                                    }

                                    _logMessage = $"Exit    시간: {exitDateTime}" +
                                        $", \nExecute 시간: {executeDateTime}" +
                                        $", \n차이: {timeDifference.TotalSeconds} 초" +
                                        $" \n==================================";

                                    using (StreamWriter writer = new StreamWriter("SwitchLog2.txt", true))
                                    {
                                        writer.WriteLine(_logMessage);
                                    }
                                    //Debug.Log($"차이: {timeDifference.TotalSeconds} 초");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}