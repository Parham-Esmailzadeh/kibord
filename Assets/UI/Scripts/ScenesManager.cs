using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;
    
    private void Awake() {
        Instance = this;
    }

    public enum Scene 
    {
        MainMenu,
        Story,
        Forest
    }

    public void LoadScene(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }

    private bool HasSeenStory() {
        if ( File.Exists(Application.dataPath + "/story.txt") ) {
            string json = File.ReadAllText(Application.dataPath + "/story.txt");

            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            return data.HasSeenStory;
        }
        return false;
    }
    private void ChangeSeenStory(){
        PlayerData data = new PlayerData
        {
            HasSeenStory = true
        };
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.dataPath + "/story.txt", json);
    }

    public void LoadNewGame() {
        if (!HasSeenStory()){
            SceneManager.LoadScene(Scene.Story.ToString());
            ChangeSeenStory();
        } else {
            SceneManager.LoadScene(Scene.Forest.ToString());
        }
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }
}