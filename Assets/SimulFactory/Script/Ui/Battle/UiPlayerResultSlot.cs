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

        // 이름 설정
        public void SetName(string name) => playerNameText.text = name;
        // 현재 결과 창 리셋
        public void ResetResult() => playerResult.gameObject.SetActive(false);

        /// <summary>
        /// 결과 설정
        /// </summary>
        /// <param name="sprite"></param>
        public void SetResult(Sprite sprite)
        {
            playerResult.sprite = sprite;
            playerResult.gameObject.SetActive(true);
        }
    }

}