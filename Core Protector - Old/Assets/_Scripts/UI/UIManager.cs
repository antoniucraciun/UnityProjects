using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable

public class UIManager : MonoBehaviour
{
    #region Menu Screens
    [Header("Menu Screens")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject playerAttributes;
    [SerializeField] private GameObject levelsMenu;
    [SerializeField] private GameObject endlessMenu;
    [SerializeField] private GameObject achievements;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private GameObject sessionMenu;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private GameObject enemiesMenu;

    private List<GameObject> currentActiveMenu;
    #endregion

    void Start()
    {
        currentActiveMenu = new List<GameObject>();
        currentActiveMenu.Add(mainMenu);
    }

    public void OnMainMenuButtonPress()
    {
        if (CheckCurrentMenu(mainMenu))
            return;
        FadeOutAndClear();
        mainMenu.SetActive(true);
        currentActiveMenu.Add(mainMenu);
        StartCoroutine(FadeWithDelay(currentActiveMenu));
    }

    public void OnLevelsMenuClick()
    {
        if (CheckCurrentMenu(levelsMenu))
            return;
        FadeOutAndClear();
        levelsMenu.SetActive(true);
        currentActiveMenu.Add(levelsMenu);
        StartCoroutine(FadeWithDelay(currentActiveMenu));
    }

    public void OnEndlessMenuClick()
    {
        if (CheckCurrentMenu(endlessMenu))
            return;
        FadeOutAndClear();
        endlessMenu.SetActive(true);
        currentActiveMenu.Add(endlessMenu);
        StartCoroutine(FadeWithDelay(currentActiveMenu));
    }

    public void OnPlayerAttributesClick()
    {
        if (CheckCurrentMenu(playerAttributes))
            return;
        FadeOutAndClear();
        playerAttributes.SetActive(true);
        currentActiveMenu.Add(playerAttributes);
        StartCoroutine(FadeWithDelay(currentActiveMenu));
    }

    public void OnAchievementsMenuClick()
    {
        if (CheckCurrentMenu(achievements))
            return;
        FadeOutAndClear();
        achievements.SetActive(true);
        currentActiveMenu.Add(achievements);
        StartCoroutine(FadeWithDelay(currentActiveMenu));
    }

    public void OnOptionsClick()
    {
        if (CheckCurrentMenu(optionsMenu))
            return;
        FadeOutAndClear();
        optionsMenu.SetActive(true);
        currentActiveMenu.Add(optionsMenu);
        StartCoroutine(FadeWithDelay(currentActiveMenu));
    }

    public void OnShopMenuClick()
    {
        if (CheckCurrentMenu(shopMenu))
            return;
        FadeOutAndClear();
        shopMenu.SetActive(true);
        currentActiveMenu.Add(shopMenu);
        StartCoroutine(FadeWithDelay(currentActiveMenu));
    }

    public void OnSessionMenuClick()
    {
        if (CheckCurrentMenu(sessionMenu))
            return;
        FadeOutAndClear();
        sessionMenu.SetActive(true);
        currentActiveMenu.Add(sessionMenu);
        StartCoroutine(FadeWithDelay(currentActiveMenu));
    }

    private bool CheckCurrentMenu(GameObject other)
    {
        foreach (var item in currentActiveMenu)
        {
            if (item.Equals(other))
                return true;
        }
        return false;
    }

    private void FadeOutAndClear()
    {
        foreach (var item in currentActiveMenu)
        {
            item.GetComponent<Animator>().SetTrigger("FadeOut");
            StartCoroutine(DeactivateWithDelay(item));
        }
        currentActiveMenu.Clear();
    }

    private IEnumerator DeactivateWithDelay(GameObject item)
    {
        yield return new WaitForSeconds(1.0f);
        item.SetActive(false);
    }

    private IEnumerator FadeWithDelay(List<GameObject> objects)
    {
        yield return new WaitForSeconds(1.0f);
        foreach (var item in objects)
        {
            item.GetComponent<Animator>().SetTrigger("FadeIn");
        }
    }
}
