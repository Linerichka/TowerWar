using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private string _nameSceneToLoad;

    void Start()
    {
        Init();
        LoadScene();
    }

    private void Init()
    {

    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_nameSceneToLoad);
    }
}
