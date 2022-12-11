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
            MakeMyMessage((long)Define.CHAT_TYPE.None, GetInputText(),"");
        }

        public void MakeMyMessage(long chatType, string chatText, string targetName = "")
        {
            try
            {
                //C_Chat.ChatC(chatType, chatText, targetName);
            }
            catch (Exception e)
            {
                print(e);
            }

            myMessagePref.GetComponent<TMP_Text>().text = chatText;

            //채팅창에 최근 12개 메세지까지 표시
            if (messagePrefParent.transform.childCount >= maxMessageCount)
            {
                Destroy(messagePrefParent.transform.GetChild(0).gameObject);
            }
            Instantiate(myMessagePref, messagePrefParent.transform);
        }

        public void MakeOtherMessage(string chatText)
        {
            otherMessagePref.GetComponent<TMP_Text>().text = chatText;
            if (messagePrefParent.transform.childCount >= maxMessageCount)
            {
                Destroy(messagePrefParent.transform.GetChild(0).gameObject);
            }
            Instantiate(otherMessagePref, messagePrefParent.transform);
        }
    }

}