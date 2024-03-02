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
        // B ������Ʈ�� ���� ���� ��� \\ ����.exe
        //string buildBPath = "D:\\����Ƽ ���������\\My Practice\\My Practice1"; 
        //Process.Start(buildBPath);


        Application.Quit();

    }


    
    public  bool playerIsNearPortal = false;
    void OnTriggerEnter(Collider other)
    {
        // �÷��̾� Tag�� ���� ������Ʈ�� �浹�ϸ� true�� �ٲ��ִ� ������ ��
        if (other.CompareTag("Player")) 
        {
            playerIsNearPortal = true;
        }
    }
}
