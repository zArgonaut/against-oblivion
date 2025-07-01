// Responsável por salvar e carregar configurações básicas de áudio.
// Futuramente este sistema deve armazenar volumes individuais de mixers
// e aplicar as configurações ao inicializar o jogo.
using UnityEngine;

public class SaveLoadAudioManager : MonoBehaviour
{
    [Range(0f, 1f)]
    public float volume = 1f;

    const string VolumeKey = "MasterVolume";

    void Awake()
    {
        Load();
    }

    // Permite ajustar o volume em tempo real e salvar a preferência.
    public void SetVolume(float value)
    {
        volume = Mathf.Clamp01(value);
        AudioListener.volume = volume;
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat(VolumeKey, volume);
        PlayerPrefs.Save();
        AudioListener.volume = volume;
    }

    public void Load()
    {
        volume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        AudioListener.volume = volume;
        // TODO: substituir por controle de AudioMixer quando implementado
    }
}
