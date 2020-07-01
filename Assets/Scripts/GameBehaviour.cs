using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;
    public bool showWinScreen = false;
    public bool showLossScreen = false;

    private int _itemsCollected = 0;
    public int Items

    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            if (_itemsCollected >= maxItems)
            {
                labelText = "You've find all the items!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    private int _playerHP = 3;
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);
            if (_playerHP <= 0)
            {
                labelText = "Continue?";
                showLossScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "Ouch... that's gonna hurt.";
            }
        }
    }

    private void OnGUI()
    {
        // showing player's health
        GUI.Box(new Rect(20,20,150,25), "Player Health: " + _playerHP);
        // showing how many items player collected
        GUI.Box(new Rect(20,50,150,25), "Items Collected: " + _itemsCollected);
        // showing text that reacts on collecting items
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {
            // creating button that restarts the game if win or lose condition was met
            if (GUIButton("YOU WON!"))
            {
                RestartLevel();
            }
        }
        if (showLossScreen)
        {
            if (GUIButton("You lose..."))
            {
                RestartLevel();
            }
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    bool GUIButton(string winOrLose)
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 100,
                Screen.height / 2 - 50, 200, 100), winOrLose))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
