using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SimulFactory.Game.Event;
using SimulFactory.System.Common;
using System;

namespace SimulFactory.Manager
{
    public class ChattingManager : MonoSingleton<ChattingManager>
    {
        public GameObject myMessagePref;
        public GameObject otherMessagePref;
        public GameObject messagePrefParent;
        public TMP_InputField inputField;
        public int maxMessageCount;

        private string text;

        private string GetInputText()
        {
            this.text = inputField.GetComponent<TMP_InputField>().text;
            return this.text;
        }

        public void SendButtonClicked()
        {
            C_Chat.ChatC((long)Define.CHAT_TYPE.None, GetInputText(), "");
        }

        public void MakeMyMessage(string userName, string chatText)
        {
            myMessagePref.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>().text = userName;
            myMessagePref.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = chatText;
            if (messagePrefParent.transform.childCount >= maxMessageCount)
            {
                Destroy(messagePrefParent.transform.GetChild(0).gameObject);
            }
            Instantiate(myMessagePref, messagePrefParent.transform);
        }

        public void MakeOtherMessage(string userName, string chatText)
        {
            otherMessagePref.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>().text = userName;
            otherMessagePref.transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>().text = chatText;
            if (messagePrefParent.transform.childCount >= maxMessageCount)
            {
                Destroy(messagePrefParent.transform.GetChild(0).gameObject);
            }
            Instantiate(otherMessagePref, messagePrefParent.transform);
        }
    }

}