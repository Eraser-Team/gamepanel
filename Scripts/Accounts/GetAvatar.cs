using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetAvatar : MonoBehaviour
{
    public string jsonUrl;
    public Image image;

    private void Start()
    {
        StartCoroutine(LoadImage());
    }

    private IEnumerator LoadImage()
    {
        UnityWebRequest request = UnityWebRequest.Get(jsonUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;
            MyData data = JsonUtility.FromJson<MyData>(json);
            string avatarUrl = data.avatar;

            UnityWebRequest imageRequest = UnityWebRequestTexture.GetTexture(avatarUrl);
            yield return imageRequest.SendWebRequest();

            if (imageRequest.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(imageRequest);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                image.sprite = sprite;
            }
            else
            {
                Debug.Log("Failed to load image: " + imageRequest.error);
            }
        }
        else
        {
            Debug.Log("Failed to load JSON: " + request.error);
        }
    }

    [System.Serializable]
    private class MyData
    {
        public string avatar;
    }
}