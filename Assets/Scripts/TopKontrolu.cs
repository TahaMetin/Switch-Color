using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TopKontrolu : MonoBehaviour {

    public string mevcutRenk;
    private Color topunRengi;
    public Color Turkuaz;
    public Color Sari;
    public Color Kirmizi;
    public Color Mor;
    public Text skorYazisi;
    public Text MaksSkorYazisi;
    public int MaksSkor;
    public static int skor = 0;
    public GameObject[] cemberler;
    public GameObject renktekeri;
    int sayac = 0;
    int olasılık;


    public float ziplamaKuvveti= 15f;
	void Start () {
        RastgeleRenkBelirle();
        topunRengi = GetComponent<SpriteRenderer>().color;
        skor = 0;
        skorYazisi.text = skor.ToString();
        MaksSkor = PlayerPrefs.GetInt("Maksimum Skor");
        MaksSkorYazisi.text = MaksSkor.ToString();
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.GetComponent<Rigidbody2D>().isKinematic == true)
            {
                gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
            GetComponent<Rigidbody2D>().velocity = Vector2.up * ziplamaKuvveti;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SkoruArttir")
        {
            skor += 10;
            skorYazisi.text = skor.ToString();

            if (skor > MaksSkor)
            {
                MaksSkor = skor;
                MaksSkorYazisi.text = skor.ToString();
                PlayerPrefs.SetInt("Maksimum Skor",MaksSkor);

            }
            olasılık = Random.Range(0, 6);
            sayac++;

            if (sayac % 2 == 0)
            {
                if (olasılık > 2)
                {
                    olasılık = 2;
                }
                Instantiate(cemberler[olasılık], new Vector3(transform.position.x, transform.position.y + 6f, transform.position.z), transform.rotation);
                olasılık = Random.Range(0, 3);
                if (olasılık == 1)
                {
                    Instantiate(renktekeri, new Vector3(transform.position.x, transform.position.y + 6f, transform.position.z), transform.rotation);

                }
                else if (olasılık == 0)
                {
                    Instantiate(renktekeri, new Vector3(transform.position.x, transform.position.y + 9f, transform.position.z), transform.rotation);

                }
            }
            Destroy(collision.gameObject);
            return;
        }
        if (collision.tag == "RenkTekeri")
        {
            RastgeleRenkBelirle();
            Destroy(collision.gameObject);
            return;
        }

        if (collision.tag != mevcutRenk ) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Destroy(gameObject);
        }
    }

    void RastgeleRenkBelirle()
    {
        topunRengi = GetComponent<SpriteRenderer>().color;
        int rastgeleSayi = Random.Range(0, 4);
        Debug.Log(rastgeleSayi);
        switch(rastgeleSayi)
        {
            case 0:
                if (topunRengi == Turkuaz)
                {
                    RastgeleRenkBelirle();
                    return;
                }
                mevcutRenk = "Turkuaz";
                topunRengi = Turkuaz;
                break;
            case 1:
                if (topunRengi == Sari)
                {
                    RastgeleRenkBelirle();
                    return;

                }
                mevcutRenk = "Sari";
                topunRengi = Sari;
                break;
            case 2:
                if (topunRengi == Kirmizi)
                {
                    RastgeleRenkBelirle();
                    return;

                }
                mevcutRenk = "Kirmizi";
                topunRengi = Kirmizi;
                break;
            case 3:
                if (topunRengi == Mor)
                {
                    RastgeleRenkBelirle();
                    return;

                }
                mevcutRenk = "Mor";
                topunRengi = Mor;
                break;
        }
        GetComponent<SpriteRenderer>().color=topunRengi;
    }


   


}
