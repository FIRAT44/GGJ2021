using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AnaMenuController : MonoBehaviour
{
   public void OyunaGir()
    {
        SceneManager.LoadScene("AraSahne");
    }

    public void OyundanCik()
    {
        Application.Quit();
        Debug.Log("Oyundan Çıkıldı");
    }
}
