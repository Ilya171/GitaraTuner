using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

 public class PlayTheGameButton : LevelAbstract
{


    void Awake()
    {
        Button _playButton = this.GetComponent<Button>();
        _playButton.onClick.AddListener(LoadTheGame);
    }
    public virtual void LoadTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        Debug.Log("Load");
        LevelAbstract.lev =1;
    }
}
