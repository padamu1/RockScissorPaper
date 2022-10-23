using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimulFactory.System.Common;

public class ShowCard : MonoSingleton<ShowCard>
{
    public GameObject rock, scissor, paper;

    public void EnemyCard(string card)
    {
        /*
        Destroy(rock);
        Destroy(scissor);
        Destroy(paper);
        */

        switch (card)
        {
            case "rock":
                Instantiate(rock);
                break;
            case "scissor":
                Instantiate(scissor);
                break;
            case "paper":
                Instantiate(paper);
                break;
            default:
                break;
        }
    }

    /*
    private void Start()
    {
        Instantiate(rock);
    }
    */
}
