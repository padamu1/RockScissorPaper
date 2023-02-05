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
    private string[] pixel_data;

    private StringBuilder sb;

    // Start is called before the first frame update
    void Start()
    {
        sb = new StringBuilder();

        pixel_data = new string[64];
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
                SendPixel(sb.ToString().TrimEnd(','));               
            });
    }


   
    public static void SendPixel(string data)
    {
        Dictionary<byte, object> param = new Dictionary<byte, object>();
        param.Add(0, 1l);
        param.Add(1, data);
        param.Add(2, "");
        SocketManager.GetInstance().SendPacket((byte)Define.EVENT_CODE.ChatC, param);  // ChatC = > ?
    }
}
