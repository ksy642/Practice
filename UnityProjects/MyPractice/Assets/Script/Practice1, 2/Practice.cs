using UnityEngine;

public class Practice : MonoBehaviour
{
    public RectTransform contents;
    public string[] Arr = new string[3];

    public bool playerIsNearPortal = false;
    void OnTriggerEnter(Collider other)
    {
        // �÷��̾� Tag�� ���� ������Ʈ�� �浹�ϸ� true�� �ٲ��ִ� ������ ��

        Debug.Log("�׽�Ʈ1");

        if (other.CompareTag("Player"))
        {
            Debug.Log("�׽�Ʈ2");

            playerIsNearPortal = true;
            Debug.Log("�浹����" + playerIsNearPortal);
        }
    }


    void Start()
    {
        NewbuttonText();
    }

    void NewbuttonText()
    {
        Arr[0] = "asd";
        Arr[1] = "dfg";
        Arr[2] = "hjk";

        ButtonList2 TextMeshProUGUI = Resources.Load<ButtonList2>("Button2");

        foreach (string item in Arr)
        {
            ButtonList2 temp = Instantiate(TextMeshProUGUI, contents);
            temp.buttonText.text = item;
        }

        //for (int i = 0; i < 3; i++)
        //{
        //    ButtonList2 temp = Instantiate(TextMeshProUGUI, contents);
        //    temp.buttonText.text = Arr[i];
        //}
    }

    /*   void BlockInit()
   {
       for(int i=0; i<7; i++)
       {
           //Instantiate<GameObject>(this.block, contents.transform);
           GameObject _obj = Instantiate(block, contents.transform) as GameObject;
           BlockList.Add(_obj);
           BlockList[i].SetActive(true);
       }
           BlockList[3].SetActive(false);
   }*/
}
