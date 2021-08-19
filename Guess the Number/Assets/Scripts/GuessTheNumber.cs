using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessTheNumber : MonoBehaviour
{
   public InputField input;
   public Text infoText;

   private int guessNumber;
   private int usersGuess;

    void Start()
    {
        guessNumber = Random.Range(0,100);
    }

    public void checkGuess()
    {
        usersGuess = int.Parse(input.text);

        if(usersGuess==guessNumber)
        {
            infoText.text = "You Guessed it right!";
        }

        else if(usersGuess > guessNumber)
        {
            infoText.text = "Your guess is greater than the actual number";
        }

        else if(usersGuess < guessNumber)
        {
            infoText.text = "Your guess is lesser than the actual number";
        }
        else
        {
            infoText.text = "Enter a valid input";
        }

        input.text="";
        
    }
}
