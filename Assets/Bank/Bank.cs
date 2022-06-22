using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI totalBalanceText;


    public int CurrentBalance
    { 
        get { return currentBalance; }
    }

    private void Awake()
    {
        currentBalance = startingBalance;
    }

    private void Start()
    {
        DisplayBalance();
    }

    private void DisplayBalance()
    {
        totalBalanceText.text = "Gold: " + CurrentBalance.ToString();
    }

    public void Deposite(int amount)
    {
        // guards againsts negative values
        currentBalance += Mathf.Abs(amount);
        DisplayBalance();
    }

    public void Widthdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        DisplayBalance();
        if (currentBalance < 0)
        {
            // lost the game
            ReloadScene();

        }
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }    
}
