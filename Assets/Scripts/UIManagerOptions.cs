using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerOptions : MonoBehaviour
{ 
    public static UIManagerOptions sharedInstance;
    
    public static string PLAYER_USERNAME = "playerUsername";

    [SerializeField] private GameObject playerPreview;
    [SerializeField] private Material playerMaterial;

    [SerializeField] private TMP_InputField usernameInputField;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

   

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Configuramos la forma de la vista previa del player
        ShowPlayerShape();
        
        // Configuramos el color de la vista previa del player
        ShowPlayerColor();
        
        // Configuramos el nombre de usuario del player
        ShowPlayerUsername();
        
        // Configuramos el volumen de la música y los sfx
        ShowMusicAndSFXVolume();

     
    }

    public void ChangeShape(int playerShape)
    {
        /*
        * PLAYER SHAPE
        * 0: sphere
        * 1: cube
        * 2: capsule
        */
        
        // Dejamos activo el único hijo que coincide con el parámetro playerShape
        for (int i = 0; i < playerPreview.transform.childCount; i++)
        {
            playerPreview.transform.GetChild(i).gameObject.SetActive(i == playerShape);
        }
        
        // Guardamos el cambio en PlayerPrefs
        PlayerPrefs.SetInt(PlayerVisuals.PLAYER_SHAPE, playerShape);
    }
    
    public void ChangeColor(int color)
    {
        /*
        * PLAYER COLOR
        * 0: red
        * 1: green
        * 2: blue
        */
        
        // Cambiamos el color del material
        playerMaterial.color = DataPersistence.sharedInstance.playerColors[color];
        
        // Guardamos el cambio en PlayerPrefs
        PlayerPrefs.SetInt(PlayerVisuals.PLAYER_COLOR, color);
    }
    
    public void ChangeUsername()
    {
        string username = usernameInputField.text;

        if (username != "") 
        {
            // Guardamos el nombre de usuario en PlayerPrefs
            PlayerPrefs.SetString(PLAYER_USERNAME, username);
        }
    }

    private void ShowPlayerShape()
    {
        if (PlayerPrefs.HasKey(PlayerVisuals.PLAYER_SHAPE))
        {
            ChangeShape(PlayerPrefs.GetInt(PlayerVisuals.PLAYER_SHAPE));
        }
        else
        {
            // Si no hay valores guardados, por defecto mostramos el cubo
            ChangeShape(1);
        }
    }

    private void ShowPlayerColor()
    {
        if (PlayerPrefs.HasKey(PlayerVisuals.PLAYER_COLOR))
        {
            ChangeColor(PlayerPrefs.GetInt(PlayerVisuals.PLAYER_COLOR));
        }
        else
        {
            // Si no hay valores guardados, por defecto mostramos el color verde
            ChangeColor(1);
        }
    }

    private void ShowPlayerUsername()
    {
        string username;
        if (PlayerPrefs.HasKey(PLAYER_USERNAME))
        {
            username = PlayerPrefs.GetString(PLAYER_USERNAME);
        }
        else
        {
            username = "ENTER USERNAME";
        }

        usernameInputField.placeholder.GetComponent<TextMeshProUGUI>().text = username;
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat(MusicManager.MUSIC_VOLUME, volume);
    }
    
    public void SetSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat(MusicManager.SFX_VOLUME, volume);
    }

    private void ShowMusicAndSFXVolume()
    {
        float musicVolume, sfxVolume;
        if (PlayerPrefs.HasKey(MusicManager.MUSIC_VOLUME))
        {
            musicVolume = PlayerPrefs.GetFloat(MusicManager.MUSIC_VOLUME);
        }
        else
        {
            musicVolume = MusicManager.DEFAULT_MUSIC_VOLUME;
        }

        if (PlayerPrefs.HasKey(MusicManager.SFX_VOLUME))
        {
            sfxVolume = PlayerPrefs.GetFloat(MusicManager.SFX_VOLUME);
        }
        else
        {
            sfxVolume = 1f;
        }

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
    }

}
