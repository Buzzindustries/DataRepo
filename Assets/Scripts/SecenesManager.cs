
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SecenesManager : MonoBehaviour
{
     public static SecenesManager SM { get; private set;}


    private void Awake() 
    {
        if (SM != null)
        {
            Destroy(gameObject);
            return;
        }
        SM = this;
        DontDestroyOnLoad(gameObject);
    } 



    public void LoadScene(int sceneId) => SceneManager.LoadScene(sceneId);

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }
}
