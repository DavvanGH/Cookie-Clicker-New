using TMPro;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    int cookies;
    [SerializeField] TextMeshProUGUI cookiesText;
    [SerializeField] TextMeshProUGUI grandmacost;
    [SerializeField] TextMeshProUGUI upgradecost;
    [SerializeField] GameObject winnerbutton;
    [SerializeField] TextMeshProUGUI winnertext;
    [SerializeField] AudioClip buysound;
    [SerializeField] AudioClip failsound;
    [SerializeField] AudioClip winsound;
    float timer;

    public bool hasGrandma;

    public int grandmaCost;

    public double cookieMultiplier = 1.5;

    public int upgradeCost = 10;

    private void Update()

    {
        if (hasGrandma)
        {
            if (timer >= 1)
            {
                timer = 0;
                AddCookie();
            }
            timer += Time.deltaTime;

        }
        cookiesText.text = cookies.ToString();

    }

    public void AddCookie()
    {
        cookies += (int)cookieMultiplier;

        cookiesText.text = cookies.ToString();

        Debug.Log("You Clicked The Cookie!");

        GetComponent<AudioSource>().Play();
    }

    public void BuyGrandma()
    {
        if (cookies >= grandmaCost)
        {

            cookies -= grandmaCost;

            hasGrandma = true;

            grandmaCost *= 2;

            Debug.Log("You bought a grandma!");

            grandmacost.text = grandmaCost.ToString();

            GetComponent<AudioSource>().PlayOneShot(buysound);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(failsound);
        }

    }

    public void BuyCookieUpgrade()
    {
        if (cookies >= upgradeCost)
        {
            cookies -= upgradeCost;

            cookieMultiplier *= 1.5;

            upgradeCost *= 2;

            cookiesText.text = cookies.ToString();

            Debug.Log("You bought 2x cookies, you now have: " + cookieMultiplier);

            upgradecost.text = upgradeCost.ToString();

            GetComponent<AudioSource>().PlayOneShot(buysound);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(failsound);
        }


    }

    public void Winner()
    {
        if (cookies >= 100000)
        {
            winnertext.text = "Congrats! You win!";
            winnerbutton.SetActive(false);

            Debug.Log("You won the game!");

            GetComponent<AudioSource>().PlayOneShot(winsound);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(failsound);
        }
    }
}
