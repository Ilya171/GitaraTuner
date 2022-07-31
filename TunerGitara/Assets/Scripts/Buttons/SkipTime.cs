using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipTime : MonoBehaviour
{
    void Awake()
    {
        Button _skipTimeButton = this.GetComponent<Button>();
    }
    public void StartSkiptime()
    {
        Time.timeScale = 2;
    }
    public void StopSkiptime()
    {
        Time.timeScale = 1;
    }
}
