using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SimulFactory.Ui.Battle
{
    public class UiPlayerTotalResultSlot : MonoBehaviour
    {
        [SerializeField] private List<Image> resultImages;
        [SerializeField] private TMP_Text userName;
        private int currentWinCount;
        private void OnEnable()
        {
            currentWinCount = 0;
        }
        public void ResetUi() => resultImages.ForEach(resultImage => resultImage.color = Color.black);
        public void SetName(string name) => userName.text = name;
        public void IncreaseWinCount() => resultImages[currentWinCount++].color = Color.yellow;
    }
}