﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{

    public GameObject loginPanel;

    public InputField createPasswordText1;
    public InputField createPasswordText2;

    public InputField enterPasswordText;

    public GameObject enterPasswordPanel;
    public GameObject createPasswordPanel;

    private void Awake()
    {
        loginPanel.SetActive(true);
    }

    public void ConfirmPasswordButton()
    {
        if (enterPasswordText.text == SaveManager.Decrypt(SaveManager.instance.saveData.password))
        {
            SaveManager.instance.SetLoadedSaveData();
            loginPanel.SetActive(false);
        }
    }

    public void ConfirmPasswordCreationButton()
    {
        if (createPasswordText2.text != null && createPasswordText2.text == createPasswordText1.text)
        {
            SaveManager.instance.saveData.password = SaveManager.Encrypt(createPasswordText2.text);

            createPasswordPanel.SetActive(false);
            enterPasswordPanel.SetActive(true);
        }
    }
}