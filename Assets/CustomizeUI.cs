using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using SimulFactory.WebSocket;
using SimulFactory.System.Common;
using SimulFactory.Game.Event;

public class CustomizeUI : MonoBehaviour
{
    [SerializeField]
    private Button ConfirmButton;
    [SerializeField]
    private Button CancelButton;
    [SerializeField]
    private GameObject pixels;
    [SerializeField]
    private string[] pixel_data;

    // Start is called before the first frame update
    void Start()
    {
        pixel_data = new string[64];
        Color col;
        ConfirmButton.OnClickAsObservable()
            .Subscribe(_ => { 
                for(int i = 0; i < pixel_data.Length; i++)
                {
                    col = pixels.transform.GetChild(i).GetComponent<Pixel>().Col;
                    pixel_data[i] = ColorUtility.ToHtmlStringRGB(col);
                }
                //SendPixel(pixel_data);
                C_Chat.ChatC(0, pixel_data[4]);
            });
    }


   
    public static void SendPixel(string[] data)
    {
        Dictionary<byte, object> param = new Dictionary<byte, object>();
        param.Add(0, data);
        SocketManager.GetInstance().SendPacket((byte)Define.EVENT_CODE.ChatC, param);
    }
}
