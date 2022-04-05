using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager _instance ;

    public static GameManager GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField] private AudioSource YouLose;
    private byte count = 0;

    private void Start()
    {
        YouLose = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (count == 0 && GameObject.Find("pong") == null)
        {
            YouLose.Play();
            count++;
        }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Restart");
    }
    public void Goto_MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Goto MainMenu");
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
