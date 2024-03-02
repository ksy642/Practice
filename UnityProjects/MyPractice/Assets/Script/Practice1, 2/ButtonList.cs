using TMPro;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class ButtonList : MonoBehaviour
{
    public TextMeshProUGUI buttonText;

    void Start()
    {
        //string message = PlayerPrefs.GetString("TheKey", "Default Text");
        //buttonText.text = message;

        string[] commandLineArgs = System.Environment.GetCommandLineArgs();

        if (commandLineArgs.Length > 0)
        {
            string dataFromA = commandLineArgs[1];
            Debug.Log("Received data from A: " + dataFromA);

            buttonText.text = dataFromA;
        }


    }

    public void TouchButtonA()
    {
        // B 프로젝트의 실행 파일 경로 \\ 파일.exe
        //string buildBPath = "D:\\유니티 빌드용폴더\\My Practice\\My Practice1"; 
        //Process.Start(buildBPath);


        Application.Quit();

    }


    
    public  bool playerIsNearPortal = false;
    void OnTriggerEnter(Collider other)
    {
        // 플레이어 Tag를 가진 오브젝트가 충돌하면 true로 바꿔주는 역할을 함
        if (other.CompareTag("Player")) 
        {
            playerIsNearPortal = true;
        }
    }
}
