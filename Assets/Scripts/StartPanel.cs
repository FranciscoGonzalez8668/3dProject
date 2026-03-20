using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    [SerializeField] private GameObject Ball;


    void start()
    {
        panel.SetActive(true);
        Ball.SetActive(false);
    }

    public void OnPlayButton()
    {
        panel.SetActive(false);
        Ball.SetActive(true);
    }
}
