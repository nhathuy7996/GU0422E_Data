using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TestWebRequest : MonoBehaviour
{
    [SerializeField] RawImage avatar;
    AspectRatioFitter fitter;
    // Start is called before the first frame update
    void Start()
    {
        fitter = avatar.GetComponent<AspectRatioFitter>();
        StartCoroutine(GetRequest("https://d1whtlypfis84e.cloudfront.net/guides/wp-content/uploads/2019/08/07124216/unity-in-divesity-2-1024x768.png"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetRequest(string uri)
    {
       
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri);


            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.InProgress:
                    break;

                case UnityWebRequest.Result.ConnectionError:
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    break;

                case UnityWebRequest.Result.DataProcessingError:
                    break;
                case UnityWebRequest.Result.Success:
                    avatar.texture = DownloadHandlerTexture.GetContent(request);
                    float ratio = avatar.texture.width / avatar.texture.height;
                    fitter.aspectMode = AspectRatioFitter.AspectMode.FitInParent;
                    fitter.aspectRatio = ratio;
                    break;
            }
        
    }
}
