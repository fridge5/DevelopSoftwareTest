using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Xml.Linq;

public class HighScore : MonoBehaviour
{
    //Declare Variables
    [SerializeField]
    TMP_Text messageDisplay;

    [SerializeField]
    TMP_Text playerNameDisplay;

    [SerializeField]
    TMP_Text playerScoreDisplay;

    [SerializeField]
    TMP_Text[] highScoreDisplays;

    [SerializeField]
    TMP_Text[] highScoreNameDisplays;

    // Variables to store the players name and score
    bool highScoreAchieved = false;

    









    // Start is called before the first frame update
    void Start()
    {

        //Call PrepareData()
        PrepareData();

        //Call DisplayData()
        DisplayData();

    }

    void PrepareData()
    {
        //Display Variables 
        int newScore;
        string newName;
        //READ playerScore and playerName variables from Unity PlayerPrefs
        int playerScore = PlayerPrefs.GetInt("playerScore");
        string playerName = PlayerPrefs.GetString("playerName");

        //INITIALISE newScore and newName variables to be equal to playerScore and playerName
        newScore = playerScore;
        newName = playerName;

        //Score Index from 0-2
        for (int scoreIndex = 0; scoreIndex <= 2; scoreIndex++)
        {
            int highScore = PlayerPrefs.GetInt("highScore" + scoreIndex);
            string highScoreName = PlayerPrefs.GetString("highScoreName" + scoreIndex);
          //IF newScore is greater than highScore THEN
            if (newScore > highScore)
            {
                //SET highScoreAchieved to true
                highScoreAchieved = true;
                //WRITE newScore and newScoreName variables into Unity PlayerPrefs for the high score and high score name at this scoreIndex
                PlayerPrefs.SetInt("highScore" + scoreIndex, newScore);
                PlayerPrefs.SetString("highScoreName" + scoreIndex, newName);
                //SET newScore equal to highScore
                newScore = highScore;
                //SET newName equal to highScoreName
                newName = highScoreName;
            }


        }

    }
    void DisplayData()
    {
        //Declare Variables
        int highScore;
        string highScoreName;
        string playerName = PlayerPrefs.GetString("playerName");
        int playerScore = PlayerPrefs.GetInt("playerScore");

        //IF highScoreAchieved is true
        if (highScoreAchieved == true)
        {
            //DISPLAY “Congratulations! You got a new high score!” to the messageDisplay 
            messageDisplay.text = "Congratulations! You got a new high Score";
        }
        else
        {
            //DISPLAY “Better luck next time!” to the messageDisplay text object
            messageDisplay.text = "Better luck next time";
        }
        //DISPLAY playerName and playerScore to the playerNameDisplay and playerScoreDisplay text objects
        playerNameDisplay.text = playerName;
        playerScoreDisplay.text = playerScore.ToString();
        //FOR scoreIndex from 0 to 2
        for (int scoreIndex = 0; scoreIndex <= 2; scoreIndex++)
        {
            
            //READ highScore and highScoreName variables from Unity PlayerPrefs using the scoreIndex
            highScore = PlayerPrefs.GetInt("highScore" + scoreIndex);
            highScoreName = PlayerPrefs.GetString("highScoreName" + scoreIndex);
            //CALL DisplayScore() with scoreIndex, highScore, and highScoreName
            DisplayScore(scoreIndex, highScore, highScoreName);
        }


    }

    void DisplayScore(int scoreIndex, int highScore, string highScoreName)
    {
        //IF score is greater than 0
        if (scoreIndex >= 0)
        {
            //DISPLAY score to the highScoreDisplays at index
            highScoreDisplays[scoreIndex].text = highScore.ToString();
        }
        else
        {
            //DISPLAY the empty string to the highScoreDisplays at index.
            highScoreDisplays[scoreIndex].text = null;
        }
        //DISPLAY name to the highScoreNameDisplays at
        highScoreNameDisplays[scoreIndex].text = highScoreName;


    }

}


