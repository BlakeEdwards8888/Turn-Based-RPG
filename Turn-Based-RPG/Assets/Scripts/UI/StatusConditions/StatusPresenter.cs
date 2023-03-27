using RPG.StatusConditions;
using TMPro;
using UnityEngine;

namespace RPG.UI.StatusConditions
{
    public class StatusPresenter : MonoBehaviour
    {
        [SerializeField] TMP_Text statusText;

        public void Setup(StatusData statusData)
        {
            statusText.text = statusData.GetStatusCode();
        }

        public string GetText()
        {
            return statusText.text;
        }
    }
}
