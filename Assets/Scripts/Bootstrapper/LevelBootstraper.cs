using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBootstraper : MonoBehaviour
{
    [SerializeField] string SceneNameForLoad;
    public void LevelRestart()
    {
        SceneManager.LoadScene(SceneNameForLoad);
    }

}
