using UnityEngine;
using UnityEngine.UI;

public class UIMin : MonoBehaviour
{
    private GameObject sciana;
    private ScianaLadowanie ok;
    public GameObject minText;
    public GameObject maxText;
    public int minpacholki;

    void Awake()
    {
        minpacholki = 200;
    }
    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        sciana = GameObject.Find("Sciana");
        ok = sciana.GetComponent<ScianaLadowanie>();
        minText.GetComponent<InputField>().text = ok.minpacholkow.ToString();

    }


    public void Zmiana(string tekst)
    {
        sciana = GameObject.Find("Sciana");
        ok = sciana.GetComponent<ScianaLadowanie>();
        ok.minpacholkow = System.Convert.ToInt32(tekst);
        minpacholki = ok.minpacholkow;
        minText.GetComponent<InputField>().text = ok.minpacholkow.ToString();
    }


    public void Dodawanie()
    {
        sciana = GameObject.Find("Sciana");
        ok = sciana.GetComponent<ScianaLadowanie>();
        ok.minpacholkow += 50;
        if (ok.maxpacholkow <= ok.minpacholkow)
        {
            ok.maxpacholkow = ok.minpacholkow + 100;
        }
        minpacholki = ok.minpacholkow;
        GameObject.Find("Max").GetComponent<UIMax>().makspacholki = ok.maxpacholkow;
        minText.GetComponent<InputField>().text = ok.minpacholkow.ToString();
        maxText.GetComponent<InputField>().text = ok.maxpacholkow.ToString();
    }

    public void Odejmowanie()
    {
        sciana = GameObject.Find("Sciana");
        ok = sciana.GetComponent<ScianaLadowanie>();
        ok.minpacholkow -= 50;
        if (ok.minpacholkow < 0) {
            ok.minpacholkow += 50;
        }
        minpacholki = ok.minpacholkow;
        minText.GetComponent<InputField>().text = ok.minpacholkow.ToString();
    }

}
