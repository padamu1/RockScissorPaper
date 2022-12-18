using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UniRx;


public class Profile : MonoBehaviour
{
    [SerializeField]
    private Button profileButton;
    void Start()
    {
        profileButton = GetComponent<Button>();
        var buttonStream = 
        profileButton.OnClickAsObservable()
         .Subscribe(_ =>
        {
            Debug.Log("test button");
        });
    }

}
