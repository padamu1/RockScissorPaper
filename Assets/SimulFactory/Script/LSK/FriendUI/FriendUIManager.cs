using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendUIManager : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject parentObject;
    private GameObject temp;
    public Sprite profileImage;
    //Image defaultImage;

    List<string> friends = new List<string>();

    public void AddFriend()
    {
        friends.Add("aa");
        friends.Add("bb");
    }

    //ģ�� ���� ����
    public void MakeObject()
    {
        temp = Instantiate(gameObject);
        temp.transform.SetParent(parentObject.transform);
        //defaultImage.sprite = profileImage;
    }

    /*
    private void Update()
    {
        if (friendRequest)
        {
            MakeObject();
        }
    }
    */

    private void Start()
    {
        //defaultImage = GetComponent<Image>();
        AddFriend();

        //��� ����
        foreach (string friend in friends)
        {
            MakeObject();
        }
    }
}
