using RPG.StatusConditions;
using UnityEngine;

namespace RPG.UI.StatusConditions
{
    public class StatusConditionPresenter : MonoBehaviour
    {
        [SerializeField] StatusCondition statusCondition;
        [SerializeField] Transform displayArea;
        [SerializeField] StatusPresenter statusPresenterPrefab;

        private void OnEnable()
        {
            statusCondition.onStatusAdded += AddToDisplay;
            statusCondition.onStatusRemoved += RemoveFromDisplay;
        }

        private void AddToDisplay(StatusData statusData)
        {
            StatusPresenter statusPresenter = Instantiate(statusPresenterPrefab, displayArea);

            statusPresenter.Setup(statusData);
        }

        private void RemoveFromDisplay(StatusData statusData)
        {
            foreach(StatusPresenter statusPresenter in displayArea.GetComponentsInChildren<StatusPresenter>())
            {
                if(statusPresenter.GetText() == statusData.GetStatusCode())
                {
                    Destroy(statusPresenter.gameObject);
                    return;
                }
            }
        }

        private void OnDisable()
        {
            statusCondition.onStatusAdded -= AddToDisplay;
            statusCondition.onStatusRemoved -= RemoveFromDisplay;
        }
    }
}
