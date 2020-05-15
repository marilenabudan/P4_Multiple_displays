using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  bool gameEnded = false;

  public void Restart()
  {
    if (gameEnded == false)
    {
      gameEnded = true;
      Debug.Log("You lost");
      
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }

}
