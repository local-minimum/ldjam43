using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wallet : MonoBehaviour {

    RailHandler rails;

    [SerializeField]
    WalletMeter popularity;

    [SerializeField]
    WalletMeter cash;

    [SerializeField]
    int balance = 80;

    [SerializeField]
    int popularityLvl = 100;

    [SerializeField]
    int costOfKilling = 5;

    private void Awake()
    {
        rails = GetComponent<RailHandler>();
    }

    private void OnEnable()
    {
        rails.OnTransaction += Rails_OnTransaction;
        rails.OnFatality += Rails_OnFatality;
        rails.OnPopularityGain += Rails_OnPopularityGain;
    }

    private void OnDisable()
    {
        rails.OnTransaction -= Rails_OnTransaction;
        rails.OnFatality -= Rails_OnFatality;
        rails.OnPopularityGain -= Rails_OnPopularityGain;
    }

    private void Start()
    {
        popularity.SetValue(popularityLvl);
        cash.SetValue(balance);
    }

    private void Rails_OnPopularityGain(int value, Transform localization)
    {
        if (popularityLvl > 0)
        {
            popularityLvl = Mathf.Min(100, popularityLvl + value);
            popularity.SetValue(popularityLvl);
        }
    }

    private void Rails_OnFatality(Train train, Person person)
    {
        popularityLvl = Mathf.Max(0, popularityLvl - costOfKilling);
        popularity.SetValue(popularityLvl);
        if (popularityLvl == 0)
        {
            StartCoroutine(DelayLoadScene("EndingAngryMob"));
        }
    }

    IEnumerator<WaitForSeconds> DelayLoadScene(string scene)
    {        
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(scene);
    }

    private void Rails_OnTransaction(int value, Transform localization)
    {
        if (balance > 0)
        {
            balance = Mathf.Clamp(value + balance, 0, 100);
            cash.SetValue(balance);
            if (balance == 0) StartCoroutine(DelayLoadScene("EndingOutOfCash"));
        }

    }
}
