using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SimulFactory.System.Common;

public class Status : MonoBehaviour
{
    public GameObject ratingStatus, winCountStatus, defeatCountStatus;
    private TextMeshProUGUI ratingText, winCountText, defeatCountText;
    private string rating, winCount, defeatCount;

    private void Awake()
    {
        ratingText = ratingStatus.GetComponent<TextMeshProUGUI>();
        winCountText = winCountStatus.GetComponent<TextMeshProUGUI>();
        defeatCountText = defeatCountStatus.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        if (UserData.GetInstance().GetPvpInfo() != null)
        {
            rating = UserData.GetInstance().GetPvpInfo().Rating.ToString();
            winCount = UserData.GetInstance().GetPvpInfo().WinCount.ToString();
            defeatCount = UserData.GetInstance().GetPvpInfo().DefeatCount.ToString();
        }

        if (rating != null && winCount != null && defeatCount != null)
        {
            ratingText.text = rating;
            winCountText.text = winCount;
            defeatCountText.text = defeatCount;
        }
    }
}