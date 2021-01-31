using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class KarakterKontrol : MonoBehaviour
{

    [SerializeField]
    GameObject sonYazi;
    [SerializeField]
    GameObject anaMenuSonKisim;



    [SerializeField]
    GameObject hazineOdası;

    [SerializeField]
    GameObject harita;


    [SerializeField]
    GameObject baslaYaziImage;
    [SerializeField]
    GameObject ferman;

    [SerializeField]
    GameObject isik;
    int deger = 0;
    int degerEtusuAcma = 0;
    [SerializeField]
    GameObject kutu;
    [SerializeField]
    GameObject buton;
    [SerializeField]
    GameObject yazi;
    [SerializeField]
    Text butonText;
    Rigidbody fizik;
    float horizontal = 0, vertical = 0;
    Animator animator;
    int degerEtusu=0;
    AudioSource sesSistemi;

    //public Animator butonAnim;

    public GameObject kafaKamerasi;
    float kafaRotUstAlt = 0, kafaRotSagSol = 0;

    Vector3 kameraArasiMesafe;
    RaycastHit hit;

    float sayi = 0;

    bool IsMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        kameraArasiMesafe = kafaKamerasi.transform.position - transform.position;
        sesSistemi = gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Hareket();
        if (horizontal != 0 || vertical!=0)
        {
            if(!sesSistemi.isPlaying)
            {
                sesSistemi.Play();
            }
        }
        else if(horizontal==0 || vertical==0)
        {
            sesSistemi.Stop();
        }
        YakınlıkKontrol();
        IsikYakma();
        HaritaAcma();
        
        kafaKamerasi.transform.position = transform.position + kameraArasiMesafe;

        kafaRotUstAlt += Input.GetAxis("Mouse Y") * Time.deltaTime * -150;
        kafaRotSagSol += Input.GetAxis("Mouse X") * Time.deltaTime * 150;

        kafaRotUstAlt = Mathf.Clamp(kafaRotUstAlt,-20,20);

        kafaKamerasi.transform.rotation = Quaternion.Euler(kafaRotUstAlt, kafaRotSagSol, transform.eulerAngles.z);

        if(horizontal !=0 || vertical!=0)
        {
            Physics.Raycast(Vector3.zero, kafaKamerasi.transform.GetChild(0).forward, out hit);
            transform.rotation = Quaternion.LookRotation(new Vector3(hit.point.x, 0, hit.point.z));
            Debug.DrawLine(Vector3.zero, hit.point);
        }
        






        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);



      


    }


    



    void Hareket()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 vec = new Vector3(horizontal, 0, vertical);
        vec = transform.TransformDirection(vec);
        fizik.position += vec * Time.deltaTime * 4;
        
        
    }

   





    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Harita")
        {
            Debug.Log("Temas oldu");
            if (sayi == 0)
            {
                buton.SetActive(true);
            }
        }
        else if(other.gameObject.tag=="Hazine")
        {
            hazineOdası.SetActive(true);
            StartCoroutine(hazineKismi());

        }
        
        

    }


    void YakınlıkKontrol()
    {
        
        if (Mathf.Abs(kutu.transform.position.z - transform.position.z) > 2f )
        {
            buton.SetActive(false);
        }
        else if(sayi==0)
        {
            buton.SetActive(true);
            
        }
    }
    public void ButonaTiklandi()
    {
        sayi++;
        Debug.Log("başarılı");
        kutu.GetComponent<Animator>().SetBool("Deger", true);
        buton.SetActive(false);
        Ferman();

    }

    void Ferman()
    {
        Vector3 asd = new Vector3(63, 40, 4); 
        ferman.SetActive(true);
        StartCoroutine(basalyaziRoutine());
        //ferman.GetComponent<RectTransform>().DOScale(asd,1f);
    }

    void IsikYakma()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && deger == 0)
        {
            
            isik.SetActive(true);
            deger++;
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift) && deger != 0)
        {
            isik.SetActive(false);
            deger--;
        }

    }

    IEnumerator basalyaziRoutine()
    {

        baslaYaziImage.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(4f);

        baslaYaziImage.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        
        yield return new WaitForSeconds(4f);

        degerEtusu++;
    }

    IEnumerator hazineKismi()
    {

        
        yield return new WaitForSeconds(4f);
        sonYazi.SetActive(true);
        sonYazi.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        anaMenuSonKisim.SetActive(true);

        yield return new WaitForSeconds(4f);

        degerEtusu++;
    }





    void HaritaAcma()
    {
        if(Input.GetKeyDown(KeyCode.E) && degerEtusuAcma==0)
        {
            harita.SetActive(true);
            degerEtusuAcma++;
        }
        else if(Input.GetKeyDown(KeyCode.E) && degerEtusuAcma !=0)
        {
            harita.SetActive(false);
            degerEtusuAcma--;
        }
        
    }
    public void AnaMenu()
    {
        SceneManager.LoadScene("AnaMenu");
    }
}
