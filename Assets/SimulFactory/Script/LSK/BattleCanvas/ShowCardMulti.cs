using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimulFactory.System.Common;

public class ShowCardMulti : MonoSingleton<ShowCardMulti>
{
    public GameObject rock, scissor, paper;
    public GameObject parentObj;
    List<GameObject> objs = new List<GameObject>();

    public void EnemyCard(string card)
    {
        switch (card)
        {
            case "rock":
                Instantiate(rock, parentObj.transform);
                objs.Add(Instantiate(rock));
                break;
            case "scissor":
                Instantiate(scissor, parentObj.transform);
                objs.Add(Instantiate(scissor));
                break;
            case "paper":
                Instantiate(paper, parentObj.transform);
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