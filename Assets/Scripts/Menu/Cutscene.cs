using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    private VideoPlayer Vplayer;

    private void Start()
    {
        SoundManager.StopBackgroundMusic();

        Vplayer = GetComponent<VideoPlayer>();
        Vplayer.SetDirectAudioVolume(0, CrossSceneInfo.musicVolume - 0.25f);

        Vplayer.loopPointReached += StartGame;

        CrossSceneInfo.levels[0].unlocked = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F4))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    private void StartGame(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    private void OnDestroy()
    {
        Vplayer.loopPointReached -= StartGame;
    }
}
