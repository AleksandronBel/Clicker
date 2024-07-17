using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using TMPro;
using UnityEngine;

public class CoinIncreaser : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreTextUI;

    [SerializeField] double[] CostDouble;
    [SerializeField] TextMeshProUGUI[] CostText;

    [SerializeField] GameObject _shopPanel;
    [SerializeField] GameObject _goalsPanel;

    WaitForSeconds _waitForMoney = new WaitForSeconds(2);

    bool _isStarted;

    double _score;
    double _clickScore = 0.00001;
    double _waitingScore = 0.00001;

    public void OnClickButton()
    {
        _score += _clickScore;
        _scoreTextUI.text = _score.ToString("0.00000") + " B";
    }

    public void IncreaseMoneyPerTap()
    {
        if (_score >= CostDouble[0])
        {
            _clickScore *= 1.1;
            _score -= CostDouble[0];

            CostDouble[0] *= 1.1;

            CostText[0].text = CostDouble[0].ToString() + " B";

            _scoreTextUI.text = _score.ToString("0.00000") + " B";

            Debug.Log("Buy IncreaseMoneyPerTap");
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void IncreaseMoneyPerSec()
    {
        if (_score >= CostDouble[1])
        {
            _score -= CostDouble[1];
            CostDouble[1] *= 2;

            CostText[1].text = CostDouble[1].ToString() + " B";


            if (!_isStarted)
                StartCoroutine(WaitForMoney());
            else
                _waitingScore *= 1.1;

            _scoreTextUI.text = _score.ToString("0.00000") + " B";
            Debug.Log("Buy IncreaseMoneyPerSec");
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }


    public void SetStateShopPanel()
    {
        _shopPanel.SetActive(!_shopPanel.activeSelf);
    }

    public void SetStateGoalsPanel()
    {
        _goalsPanel.SetActive(!_goalsPanel.activeSelf);
    }

    IEnumerator WaitForMoney()
    {
        _isStarted = true;
        while (_isStarted)
        {
            _score += _waitingScore;
            _scoreTextUI.text = _score.ToString("0.00000") + " B";
            yield return _waitForMoney;
        }
    }
}
