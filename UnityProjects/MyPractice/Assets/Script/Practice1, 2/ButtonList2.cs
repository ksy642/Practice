using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

using Debug = UnityEngine.Debug;

public class ButtonList2 : MonoBehaviour
{
    public TextMeshProUGUI buttonText;

    public void TouchButtonB()
    {
        // B ������Ʈ�� ���� ���� ���
        //string buildBPath = "D:\\����Ƽ ���������\\My Practice\\My Practice";
        //Process.Start(buildBPath);


        string buildBPath = "D:\\����Ƽ ���������\\My Practice\\My Practice";
        //string dataToSend = "Hello from A";

        // ������ �� �ν� ����
        //string dataToSend = "\"Hello from A\"";

        //Process.Start(buildBPath, dataToSend);


        string[] arguments = new string[] { "\"Hello from A\"", "\"Additional Data\"" };
        string argumentsString = string.Join(" ", arguments);

        Debug.Log(arguments[0]); // Hello from A
        Debug.Log(arguments[1]); // Additional Data
        Debug.Log(argumentsString); // ����
        Debug.Log(argumentsString[0]); // "
        Debug.Log(argumentsString[1]); // H


        Process.Start(buildBPath, argumentsString);



        //PlayerPrefs.SetString("TheKey", "Hello from BL");
        //PlayerPrefs.Save();
    }

    // buttonText ���� ButtonList.cs������ �ѱ�� �;�

}
