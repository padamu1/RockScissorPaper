using SimulFactory.System.Common;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    //[SerializeField] private Image profileImage;
    [SerializeField] private GameObject profileSettingPopup;

    [SerializeField]
    private GameObject pixels;

    [SerializeField]
    private string[] pixel_data;

    private Button button;
    void Start()
    {
        button = GetComponent<Button>();

        button
            .OnClickAsObservable()
            .Subscribe(_ =>
            {
                profileSettingPopup.SetActive(true);
            });

    }

    public void InitUserProfile()
    {
        pixel_data = UserData.GetInstance().GetMyProfile().Split(',');
        for (int i = 0; i < pixel_data.Length; i++)
        {
            ColorUtility.TryParseHtmlString("#" + pixel_data[i], out Color col);
            pixels.transform.GetChild(i).GetComponent<Pixel>().Col = col;
        }
    }
}
