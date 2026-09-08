using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int cookies;
    public TextMeshProUGUI cookiesText;


    float timer;


    public bool hasGrandma;
    public int grandmaCost;
    public int cookieMultiplier = 1;
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

    }




    public void AddCookie()
    {
        cookies += cookieMultiplier;
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

            GetComponent<AudioSource>().Play();
        }

    }

    public void BuyCookieUpgrade()
    {
        if (cookies >= upgradeCost)
        {
            cookies -= upgradeCost;
            
            cookieMultiplier *= 2;
            upgradeCost *= 2;

            cookiesText.text = cookies.ToString();

            Debug.Log("You bought 2x cookies, you now have: " + cookieMultiplier);

            GetComponent<AudioSource>().Play();
        }


    }

}
