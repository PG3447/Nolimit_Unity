using UnityEngine;
using UnityEngine.UI;

public class UIMax : MonoBehaviour
{
    private GameObject sciana;
    private ScianaLadowanie ok;
    public GameObject minText;
    public GameObject maxText;
    public int makspacholki;

    void Awake()
    {
        makspacholki = 2500;
    }

    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        sciana = GameObject.Find("Sciana");
        ok = sciana.GetComponent<ScianaLadowanie>();
        maxText.GetComponent<InputField>().text = ok.maxpacholkow.ToString();

    }

    public void Zmiana(string tekst)
    {
        sciana = GameObject.Find("Sciana");
        ok = sciana.GetComponent<ScianaLadowanie>();
        ok.maxpacholkow = System.Convert.ToInt32(tekst);
        makspacholki = ok.maxpacholkow;
        maxText.GetComponent<InputField>().text = ok.maxpacholkow.ToString();
    }


    public void Dodawanie() {
        sciana = GameObject.Find("Sciana");
        ok = sciana.GetComponent<ScianaLadowanie>();
        ok.maxpacholkow += 50;
        makspacholki = ok.maxpacholkow;
        maxText.GetComponent<InputField>().text = ok.maxpacholkow.ToString();
    }

    public void Odejmowanie() {
        sciana = GameObject.Find("Sciana");
        ok = sciana.GetComponent<ScianaLadowanie>();
        ok.maxpacholkow -= 50;
        if (ok.maxpacholkow <= 0) {
            ok.maxpacholkow += 50;
        }
        if (ok.maxpacholkow <= ok.minpacholkow)
        {
            ok.minpacholkow = ok.maxpacholkow - 50;
        }
        makspacholki = ok.maxpacholkow;
        GameObject.Find("Min").GetComponent<UIMin>().minpacholki = ok.minpacholkow;
        minText.GetComponent<InputField>().text = ok.minpacholkow.ToString();
        maxText.GetComponent<InputField>().text = ok.maxpacholkow.ToString();
    }

}
