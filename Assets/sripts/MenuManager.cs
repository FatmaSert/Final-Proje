using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startBtn, exitBtn;

    void Start()
    {

    }


    public void StartGameLevel()
    {
        SceneManager.LoadScene("gameLevel");
    }

    void Update()
    {

    }
}

