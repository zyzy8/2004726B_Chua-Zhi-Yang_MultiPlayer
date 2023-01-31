using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameApp : Patterns.Singleton<GameApp>
{
  private void Start()
  {
    SceneManager.LoadScene("Menu");
  }
}
