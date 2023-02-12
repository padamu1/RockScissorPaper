using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using SimulFactory.WebSocket;
using SimulFactory.System.Common;
using SimulFactory.Game.Event;
using System.Text;

public class CustomizeUI : MonoBehaviour
{
    [SerializeField]
    private Button ConfirmButton;
    [SerializeField]
    private Button CancelButton;
    [SerializeField]
    private GameObject pixels;
    [SerializeField]
    private Profile profile;
    [SerializeField]
    private string[] pixel_data;

    private StringBuilder sb;

    // Start is called before the first frame update
    private void OnEnable()
    {
        sb = new StringBuilder();

        //pixel_data = new string[64];
        InitUserProfile();
        Color col;
        ConfirmButton.OnClickAsObservable()
            .Subscribe(_ => {
                sb.Clear();
                for(int i = 0; i < pixel_data.Length; i++)
                {
                    col = pixels.transform.GetChild(i).GetComponent<Pixel>().Col;
                    pixel_data[i] = ColorUtility.ToHtmlStringRGB(col);
                    sb.AppendFormat("{0},",ColorUtility.ToHtmlStringRGB(col));
                  
                }
                string newProfile = sb.ToString().TrimEnd(',');
                C_SetProfile.SetProflieC(newProfile);
                UserData.GetInstance().SetMyProfile(newProfile);
                profile.InitUserProfile();
            });
    }

    void InitUserProfile()
    {
        pixel_data = UserData.GetInstance().GetMyProfile().Split(',');
        if (pixel_data.Length < 64) 
        {
            pixel_data = new string[64];
            for (int i = 0; i < pixel_data.Length; i++)
            {
                pixel_data[i] = "FFFFFF";
            }
        }
        for (int i = 0; i < pixel_data.Length; i++)
        {
            ColorUtility.TryParseHtmlString("#" + pixel_data[i],out Color col);
            pixels.transform.GetChild(i).GetComponent<Pixel>().Col = col;
        }
    }
}
