using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

 class Training : LevelAbstract
{
    void Awake()
    {
        Button _playButton = this.GetComponent<Button>();
        _playButton.onClick.AddListener(LoadTheGame);
    }
    private void LoadTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        Debug.Log("LoadTrain");
        LevelAbstract.lev = 2;
    }




}
