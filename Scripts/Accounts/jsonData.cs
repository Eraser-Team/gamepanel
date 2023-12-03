using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
public class MyData
{
    public string id;
    public string nickname;
	public string avatar;
}

public class jsonData : MonoBehaviour
{
	public Text nickText;
    private void Start()
    {
        StartCoroutine(GetRequest("http://gamepanelaccounts.7m.pl/accounts/1.json"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    MyData data = JsonUtility.FromJson<MyData>(webRequest.downloadHandler.text);
                    if (data != null)
                    {
                        Debug.Log(pages[page] + ".id: " + data.id);
                        Debug.Log(pages[page] + ".nickname: " + data.nickname);
				        nickText.text = "Nickname:  " + data.nickname.ToString() + "\nID: " + data.id.ToString();
                    }
                    break;
            }
        }
    }
}
