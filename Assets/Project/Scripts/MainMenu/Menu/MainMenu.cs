using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using Cinemachine;

public class MainMenu : MonoBehaviour
{
    // variable for the connexion
    [SerializeField] private GameObject _connexionPanel;
    [SerializeField] private GameObject _connexionCamera;

    // variable for the inscription
    [SerializeField] private GameObject _inscriptionPanel;
    [SerializeField] private GameObject _inscriptionCamera;


    public void ShowConnexionPanel()
    {
        _connexionPanel.SetActive(!_connexionPanel.activeInHierarchy);
        _inscriptionPanel.SetActive(!_inscriptionPanel.activeInHierarchy);

        _inscriptionCamera.SetActive(!_inscriptionCamera.activeInHierarchy);
        _connexionCamera.SetActive(!_connexionCamera.activeInHierarchy);
    }

    public void ShowInscriptionPanel()
    {
        _inscriptionPanel.SetActive(!_inscriptionPanel.activeInHierarchy);
        _connexionPanel.SetActive(!_connexionPanel.activeInHierarchy);

        _inscriptionCamera.SetActive(!_inscriptionCamera.activeInHierarchy);
        _connexionCamera.SetActive(!_connexionCamera.activeInHierarchy);
    }
}
