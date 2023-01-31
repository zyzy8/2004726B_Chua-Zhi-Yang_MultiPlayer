using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  public void OnClick_ButtonSinglePlayer()
  {
    SceneManager.LoadScene("SinglePlayer");
    
  }
  public void OnClick_ButtonMultiPlayer()
  {
    SceneManager.LoadScene("MultiplayerLobby");
  }
}
