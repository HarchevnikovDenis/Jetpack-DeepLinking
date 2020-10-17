using UnityEngine;
using UnityEngine.SceneManagement;

public class ProcessDeepLinkManager : MonoBehaviour
{
    public string deeplinkURL;
    public static ProcessDeepLinkManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            Application.deepLinkActivated += onDeepLinkActivated;
            if(!string.IsNullOrEmpty(Application.absoluteURL))
            {
                onDeepLinkActivated(Application.absoluteURL);
            }
            else
            {
                deeplinkURL = "[none]";
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void onDeepLinkActivated(string url)
    {
        deeplinkURL = url;

        string sceneName = url.Split("?"[0])[1];
        bool validScene;

        Debug.Log(sceneName);

        switch(sceneName)
        {
            case "MenuScene":
                validScene = true;
                break;
            case "EasyLevel":
                validScene = true;
                break;
            case "NormalLevel":
                validScene = true;
                break;
            case "HardLevel":
                validScene = true;
                break;
            default:
                validScene = false;
                break;
        }

        if (validScene) SceneManager.LoadScene(sceneName);
    }
}
