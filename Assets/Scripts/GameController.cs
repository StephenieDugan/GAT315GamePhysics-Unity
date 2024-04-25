using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GameController : MonoBehaviour
{
    [SerializeField] TMP_Text score;

    int points = 0 ;
    public int Score
    {
        get { return points; }

        set
        {
            points = value;
            score.SetText( "Score: " + points);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       // score.SetText("Score: " );

    }

    public void AddPoints(int points)
    {
        Score += points;
        print(points);
    }
}
