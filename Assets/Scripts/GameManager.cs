
using System.IO;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager GM { get; private set;}

    private string playerName;
    private int highscore;
    private string highscoreString;

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string highscoreString;
        public int  highscore;
    }


    public void Savehighscore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highscore = highscore;
        data.highscoreString = highscoreString;
        

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "highscore.json" , json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "highscore.json" ;
        
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data =  JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            highscore = data.highscore;
            highscoreString = data.highscoreString;
            
        }
    }



    public void SetName (string name) =>  playerName = name;

    public string GetName() { return playerName; }


    public void SetHighscore(string scoreString, int score) 
    {
     highscoreString = scoreString;
     highscore = score;
    }

    public int GetHighScore()  { return highscore; }
    public string GethighscoreString()  { return highscoreString; }
    
    
    private void Awake() 
    {
        if (GM != null)
        {
            Destroy(gameObject);
            return;
        }

        GM = this;
        DontDestroyOnLoad(gameObject);
        LoadHighscore();
        
    }  

}
