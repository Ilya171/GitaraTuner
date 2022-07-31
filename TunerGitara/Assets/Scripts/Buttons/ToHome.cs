using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

 class ToHome : PlayTheGameButton
{
   public override void LoadTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
        Debug.Log("Load");
        LevelAbstract.lev =1;
    }
}
