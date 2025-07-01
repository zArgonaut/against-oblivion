// Responsável por salvar e carregar configurações básicas de áudio.
// Futuramente este sistema deve armazenar volumes individuais de mixers
// e aplicar as configurações ao inicializar o jogo.
using UnityEngine;

public class SaveLoadAudioManager : MonoBehaviour
{
    public float volume = 1f;

    const string VolumeKey = "MasterVolume";

    void Awake()
    {
        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat(VolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        volume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        // TODO: aplicar volume no AudioListener ou mixer
    }
}
