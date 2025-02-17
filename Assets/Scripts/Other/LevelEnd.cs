using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    private int index;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerLife player = collision.gameObject.GetComponent<PlayerLife>();
            source.Play();

            if (index != 14)
                CrossSceneInfo.levels[index - 4].unlocked = true;
            
            CrossSceneInfo.CheckCollectible(player.collectiblesGathered, index - 5);

            SceneManager.LoadScene(index);
        }
    }
}
