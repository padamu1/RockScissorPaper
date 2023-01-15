using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace SimulFactory.Ui.Battle
{
    public class UiPlayerResultSlot : MonoBehaviour
    {
        [SerializeField] private TMP_Text playerNameText;
        [SerializeField] private Image playerResult;

        // �̸� ����
        public void SetName(string name) => playerNameText.text = name;
        // ���� ��� â ����
        public void ResetResult() => playerResult.gameObject.SetActive(false);

        /// <summary>
        /// ��� ����
        /// </summary>
        /// <param name="sprite"></param>
        public void SetResult(Sprite sprite)
        {
            playerResult.sprite = sprite;
            playerResult.gameObject.SetActive(true);
        }
    }

}