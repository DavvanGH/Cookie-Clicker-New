using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int cookies;
    public TextMeshProUGUI cookiesText;


    float timer;


    public bool hasGrandma;
    public int grandmaCost;

    private void Update()
    {
        if (hasGrandma)
        {
            if (timer >= 1)
            {
                timer = 0;
                AddCookie();
                Debug.Log("Grandma Gave you a cookie!");
            }
            timer += Time.deltaTime;

        }
        
    }




    public void AddCookie()
    {
        cookies += 1;
        cookiesText.text = cookies.ToString();
        Debug.Log("You Clicked The Cookie!");
    }

    public void BuyGrandma()
    {
        if(cookies >= grandmaCost)
        {

            cookies -= grandmaCost;

            hasGrandma = true;
            grandmaCost *= 2;
            Debug.Log("You bought a grandma!");
        }
        
    }
    

}
