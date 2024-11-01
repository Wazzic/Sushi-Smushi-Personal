using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private static SceneChange _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private int scenes;

    private void Start()
    {
        scenes = SceneManager.sceneCountInBuildSettings;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(Mathf.Clamp(SceneManager.GetActiveScene().buildIndex - 1, 0, scenes));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(Mathf.Clamp(SceneManager.GetActiveScene().buildIndex + 1, 0, scenes));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
