using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float objective;

    public static GameManager Instance;
    public GameObject player;

    public int ringPoints = 0;
    protected int maxPoints = 20;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (scene.name == "Collect-a-Ville")
        {
            Time.timeScale = 1f;
        }
    }

    public UnityEvent<GameManager> OnGetCollectable;


    public void getCollectable()
    {
        ringPoints++;
        OnGetCollectable.Invoke(this);
        if (ringPoints >= maxPoints)
        {
            ResetScene();
        }
    }

    public void getIngredient()
    {
        Debug.Log("Ingredient Collected");
        objective--;
        Destroy(gameObject);
    }

    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
    

