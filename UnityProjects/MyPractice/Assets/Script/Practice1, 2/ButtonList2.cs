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
        // B 프로젝트의 실행 파일 경로
        //string buildBPath = "D:\\유니티 빌드용폴더\\My Practice\\My Practice";
        //Process.Start(buildBPath);


        string buildBPath = "D:\\유니티 빌드용폴더\\My Practice\\My Practice";
        //string dataToSend = "Hello from A";

        // 공백을 잘 인식 못함
        //string dataToSend = "\"Hello from A\"";

        //Process.Start(buildBPath, dataToSend);


        string[] arguments = new string[] { "\"Hello from A\"", "\"Additional Data\"" };
        string argumentsString = string.Join(" ", arguments);

        Debug.Log(arguments[0]); // Hello from A
        Debug.Log(arguments[1]); // Additional Data
        Debug.Log(argumentsString); // 전부
        Debug.Log(argumentsString[0]); // "
        Debug.Log(argumentsString[1]); // H


        Process.Start(buildBPath, argumentsString);



        //PlayerPrefs.SetString("TheKey", "Hello from BL");
        //PlayerPrefs.Save();
    }

    // buttonText 값을 ButtonList.cs쪽으로 넘기고 싶어

}
