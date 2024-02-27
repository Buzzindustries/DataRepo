
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputField InputName;
    public Text HighscoreText;
    

    public void GetCurPlayerName() => GameManager.GM.SetName(InputName.text);

    public void StartNewGame(int sceneId) => SecenesManager.SM.LoadScene(sceneId);
    


     public void ExitGame() => SecenesManager.SM.ExitGame();
    

    private void Start()
    {

        HighscoreText.text = GameManager.GM.GethighscoreString();

    }
}
