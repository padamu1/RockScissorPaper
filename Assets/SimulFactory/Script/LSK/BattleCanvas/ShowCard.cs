using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimulFactory.System.Common;

public class ShowCard : MonoSingleton<ShowCard>
{
    public GameObject rock, scissor, paper;
    List<GameObject> objs = new List<GameObject>();

    public void EnemyCard(string card)
    {
        switch (card)
        {
            case "rock":
                Instantiate(rock);
                objs.Add(Instantiate(rock));
                break;
            case "scissor":
                Instantiate(scissor);
                objs.Add(Instantiate(scissor));
                break;
            case "paper":
                Instantiate(paper);
                objs.Add(Instantiate(paper));
                break;
            default:
                break;
        }
    }

    public void RoundEnd()
    {
        foreach (GameObject obj in objs)
        {
            Destroy(obj);
        }
        objs.Clear();
    }

    /*
    private void Start()
    {
        Instantiate(rock);
    }
    */
}