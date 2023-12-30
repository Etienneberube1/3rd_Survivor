using System;
using System.IO;
using System.Linq;
using System.Xml.Schema;
using TMPro;
using UnityEngine;

public class Inscription : MonoBehaviour
{
    [SerializeField] private TMP_InputField nom;
    [SerializeField] private TMP_InputField mdp;
    [SerializeField] private TMP_InputField mdp2;
    [SerializeField] private TMP_Text erreurField;

    [Serializable]
    public class Utilisateur
    {
        public string nom;
        public string mdp;

        public Utilisateur(string nom, string mdp)
        {
            this.nom = nom;
            this.mdp = mdp;
        }
    }



    public async void inscriptionValidation()
    {
        string cheminFichier = "Assets/TOm/Utilisateurs.json";
        if (NomUtilisateurExiste(cheminFichier, nom.text))
        {
            erreurField.text = "nom déja utiliser";
            return;
        }
        if (ValidationMdp())
        {
            return;
        }
        {
                using (StreamWriter writer = File.AppendText(cheminFichier))
                {
                    if (mdp.text == mdp2.text && nom.text != "")
                    {
                        Utilisateur utilisateur = new Utilisateur(nom.text, mdp.text);

                        string utilisateurJson = JsonUtility.ToJson(new SerializableUtilisateur(utilisateur));

                        writer.WriteLine(utilisateurJson);
                    }
                }
        }
    }



    [System.Serializable]
    private class SerializableUtilisateur
    {
        public string nom;
        public string mdp;

        public SerializableUtilisateur(Utilisateur utilisateur)
        {
            nom = utilisateur.nom;
            mdp = utilisateur.mdp;
        }
    }


    private bool NomUtilisateurExiste(string cheminFichier, string nomUtilisateur)
    {
        if (File.Exists(cheminFichier))
        {
                using (StreamReader reader = new StreamReader(cheminFichier))
                {
                    string ligne;
                    while ((ligne = reader.ReadLine()) != null)
                    {
                        Utilisateur utilisateur = JsonUtility.FromJson<Utilisateur>(ligne);
                        if (utilisateur.nom == nomUtilisateur)
                        {
                            return true; 
                        }
                    }
                }
        }
        return false;
    }

    public bool ValidationMdp()
    {
        if(mdp.text != mdp2.text)
        {
            erreurField.text = "les mots de passe ne sont pas identique";
            return true;
        }
        else if(mdp.text.Length < 8 || !mdp.text.Any(char.IsUpper) || !mdp.text.Any(char.IsLower) || !mdp.text.Any(char.IsDigit))
        {
            erreurField.text = "le mot de passe doit contenir au moins 8 caractères, une majuscule, une minuscule et un chiffre";
            return true;
        }
        else
        {
            return false;
        }
    }
}
