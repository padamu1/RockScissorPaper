using Newtonsoft.Json;
using SimulFactory.Manager;
using SimulFactory.System.Common;
using SimulFactory.System.Common.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimulFactory.Game.Event
{
    public class S_FriendRemove
    {
        public static void FriendRemoveS(Dictionary<byte, object> param)
        {
            Define.RECEIVE_DATA_TYPE type = (Define.RECEIVE_DATA_TYPE)(long)param[0];
            switch (type)
            {
                case Define.RECEIVE_DATA_TYPE.Me:
                    bool isRequested = (bool)param[1];
                    if (isRequested)
                    {
                        UserData.GetInstance().RemoveFriend((string)param[2]);
                        Debug.Log("ģ�� ���� ����");
                    }
                    else
                    {
                        Debug.Log("ģ�� ���� ����");
                    }
                    break;
                case Define.RECEIVE_DATA_TYPE.Other:
                    string friendName = (string)param[1];
                    UserData.GetInstance().RemoveFriend(friendName);

                    // ģ�������� UI ���� �ʿ�
                    break;
            }
        }
    }
}
