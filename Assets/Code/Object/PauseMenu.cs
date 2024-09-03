using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Button upgradeSpeedButton;
    public Text upgradeSpeedPriceText;
    public Button pauseButton;
    public Button exitButton;
    public Button resetButton;
    private PlayerData playerData;

    void Start()
    {
        playerData = Object.FindFirstObjectByType<PlayerData>();
        if (playerData == null)
        {
            Debug.LogError("PlayerData not found in the scene.");
        }

        pauseMenuUI.SetActive(false);
        UpdateUpgradeButton();

        pauseButton.onClick.AddListener(Pause);

        exitButton.onClick.AddListener(ExitToMainMenu);

        resetButton.onClick.AddListener(ResetCoins);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuUI.activeSelf)
            {
                Debug.Log("Resuming game");
                Resume();
            }
            else
            {
                Debug.Log("Pausing game");
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Lanjutkan waktu
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Hentikan waktu
        UpdateUpgradeButton();
    }

    public void UpgradeSpeed()
    {
        if (playerData.coins >= playerData.upgradeCost)
        {
            playerData.SpendCoins(playerData.upgradeCost);
            playerData.upgradeLevel++;
            playerData.upgradeCost *= 2;

            PlayerMovement playerMovement = Object.FindFirstObjectByType<PlayerMovement>();
            playerMovement.IncreaseSpeed(10 * playerData.upgradeLevel);

            UpdateUpgradeButton();
        }
    }

    void UpdateUpgradeButton()
    {
        upgradeSpeedPriceText.text = "Upgrade Speed: " + playerData.upgradeCost + " Coins";
        upgradeSpeedButton.interactable = playerData.coins >= playerData.upgradeCost;
    }

    public void ClosePauseMenu()
    {
        Resume(); // Memanggil fungsi Resume untuk menutup panel
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f; // Pastikan waktu berjalan kembali sebelum berpindah scene
        SceneManager.LoadScene("Home"); // Ganti dengan nama scene menu utama Anda
    }

    public void ResetCoins()
    {
        playerData.coins = 0;
        playerData.SaveCoins(); // Simpan status koin yang di-reset
        UpdateUpgradeButton(); // Update UI koin dan tombol upgrade
        Debug.Log("Coins have been reset to 0.");
    }
}

