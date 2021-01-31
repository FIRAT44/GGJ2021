using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject buton,buton1,buton2;
    [SerializeField]
    GameObject Hikaye1,Hikaye2,Hikaye3;
    [SerializeField]
    Text buton2Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButonAna()
    {
        buton.SetActive(false);
        Hikaye1.SetActive(false);
        Hikaye2.SetActive(true);
        buton1.SetActive(true);
    }
    public void ButonBir()
    {
        buton1.SetActive(false);
        buton2.SetActive(true);
        Hikaye2.SetActive(false);
        Hikaye3.SetActive(true);
        buton2Text.text = "OYUNA BAŞLA";
    }
    public void ButonIki()
    {
        SceneManager.LoadScene("Try3");
    }
}
