using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;



public class Connexion : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField nom;
    [SerializeField]
    private TMP_InputField mdp;
    [SerializeField]
    private TMP_Text erreurField;

    [System.Serializable]
    public class SerializableUtilisateur
    {
        public string nom;
        public string mdp;
    } 

    public async void validerConnexion()
    {
        Debug.Log("mot de passe incosgdsrect");
        string nomUtilisateur = nom.text;
        string motDePasse = mdp.text;

        string cheminFichier = "Assets/TOm/Utilisateurs.json";
        using (StreamReader reader = new StreamReader(cheminFichier))
        {
            string ligne;
            while ((ligne = reader.ReadLine()) != null)
            {
                SerializableUtilisateur utilisateur = JsonUtility.FromJson<SerializableUtilisateur>(ligne);
                if (utilisateur.nom == nom.text )
                {
                    if (utilisateur.mdp == mdp.text)
                    {
                        erreurField.text = "réussie";
                        return;
                    }
                    else
                    {
                        erreurField.text = "mot de passe incorrect";
                        return;
                    }
                }
            }
            erreurField.text = "nom d'utilisateur incorrect";
        }
    }
}
