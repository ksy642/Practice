using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class Login : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TextMeshProUGUI resultText;

    private string serverURL = "받을 주소 입력";

    public void SignUp()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        StartCoroutine(RegisterUser(username, password));
    }

    IEnumerator RegisterUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("login", username);
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post(serverURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                resultText.text = "Sign Up Successful!";
            }
            else
            {
                resultText.text = "Sign Up Failed. Error: " + www.error;
            }
        }
    }


    public void SignIn()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        StartCoroutine(AuthenticateUser(username, password));
    }

    IEnumerator AuthenticateUser(string username, string password)
    {
        string url = $"{serverURL}?login={username}&password={password}";

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                resultText.text = "Sign In Successful!";
                // 서버에서 반환된 사용자 정보를 처리할 수도 있음
            }
            else
            {
                resultText.text = "Sign In Failed. Error: " + www.error;
            }
        }
    }
}
