using UnityEngine;
using TMPro;

public class RandomQuoteGen : MonoBehaviour
{
    public TMP_Text thequote;
    string[] quotes = 
    {
        "\"These balls weren\'t sky high enough\"",
        "\"The other balls were bigger\"",
        "\"Touch my balls\" \n\n- motivational quote website",
        "\"FUCK\" \n\n- You, who just lost",
        "\"Bite my tongue\" \n\n- The Dalai Lama",
        "\"The ball is so round it can change direction\" \n\n- Ariana on some stuff",
        "\"I think we agree, the balls are over.\" \n\n - George W. Bush",
        "\"The man who moves a mountain begins by carrying away small balls\" \n\n- Confucius",
        "\"I have a great idea for a movie. It\'s about a bunch of guys who have no balls.\" \n\n- David Mamet",
        "\"Some people are born to lift heavy weights, some are born to juggle golden balls\" \n\n- Max Beerbohm",
        "\"AAAAAUUUUUGGGGGHHHHH\"",
        "\"The objective is to move the opponent, not the ball. Except for when the opponent is the ball.\" \n\n- Sun Tzu",
        "\"You\'ve got to have balls and a messed up plastic surgery face to be successful in anything.\" \n\n- Simon Cowell",
        "\"It will always be me and the balls\" \n\n- Tiger \'Infidelity\' Woods",
        "\"My armpit hairs are solid steel\" \n\n- Mark Twain",
        "\"If you want to succeed, you have to have balls.\" \n\n- Mike Tyson",
        "\"I know the human being and balls can coexist peacefully.\" \n\n- George W. Bush",
        "\"Imma push these balls\" \n\n- Sisyphus",
        "\"Touch my balls\" \n\n- motivational quote website",
        "\"Imitation Crab Roe Balls? Lobster Balls? Cuttlefish Balls? SO MANY BALLS!\" \n\n - Ariana",
        "\"... [Balls]\" \n\n- Stephen Hawking"
    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thequote.SetText(quotes[Random.Range(0,quotes.Length)]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}