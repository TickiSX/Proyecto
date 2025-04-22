using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class MenuInicial : MonoBehaviour
{
    [Header("Options")]
    public Slider VolumeFX;
    public Slider VolumeMaster;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;
    private float lastVolume;
    [Header("Panels")] 
    public GameObject mainpanel; 
    public GameObject optionsPanel; 
 
    private void Awake()
    {
        VolumeFX.onValueChanged.AddListener(ChangeVolumeFX);
        VolumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
    }

    public void SetMute()
    {
        if (mute.isOn)
        {
            mixer.GetFloat("VolMaster", out lastVolume);
            mixer.SetFloat("VolMaster", -80);
        }
        else
        {
            mixer.SetFloat("VolMaster", lastVolume);
        }
    }

    public void OpenPanel(GameObject panel)
    {
        mainpanel.SetActive(false);
        optionsPanel.SetActive(false);

        panel.SetActive(true);
        PlaySoundButton();
    }

    public void Jugar() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    public void Salir ()
    {
        Debug.Log("salir...");
        Application.Quit();
    }

    public void Pagar()
    {
        Debug.Log("Pagando...");
        Application.Quit();
    }


    public void ChangeVolumeMaster(float v) 
    {
        mixer.SetFloat("VolMaster", v);
    }

    public void ChangeVolumeFX(float v)
    {
        mixer.SetFloat("VolFX", v);
    }

    public void PlaySoundButton()
    {
        fxSource.PlayOneShot(clickSound);
    }
}

