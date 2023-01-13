using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PenduManager : MonoBehaviour
{
    //variables
    public string motADeviner;
    public char[] motCache;
    private List<string> liste1 = new List<string>() { "BANANE", "CHOCOLAT", "POMME", "SOLEIL" };
    public int essais = 0;
    public bool gameOver;
    PenduStarter penduStarter;

    public PenduManager(PenduStarter penduStarter)
    {
        this.penduStarter = penduStarter;
        ChoisirMot(liste1);
        AfficherMot();
    }

    //Validation lettre selectionnée :
    public void TestLettre(char lettre, Image image )
    {
        bool lettrePresente = false;
        for (int i = 0; i < motADeviner.Length; i++)
        {
            if (motADeviner[i] == lettre)
            {
                lettrePresente = true;
            }
        
        }
        ValidationLettre(lettrePresente, lettre, image);
    }

    //Selection d'un mot aléatoire
    private void ChoisirMot(List<string> list)
    {
        int rnd = Random.Range(0, list.Count);
        motADeviner = list[rnd];
        motCache = new char[motADeviner.Length];
    }

    //afficher les "-" du mot à deviner
    public void AfficherMot()
    {
        for (int i = 0; i < motADeviner.Length; i++)
        {
            motCache[i] = '_';
        }
        penduStarter.uIManager.affichageMot.text = CreationMot();
    }
    //afficher les lettres du mot
    public void AfficherMot(char lettre)
    {
        for (int i = 0; i < motADeviner.Length; i++)
        {
            if (motADeviner[i] == lettre)
            {
                motCache[i] = lettre;
            }
        }
        penduStarter.uIManager.affichageMot.text = CreationMot();
    }
    public string CreationMot()
    {
        string motAAfficher = "";
        for (int i = 0; i < motCache.Length; i++)
        {
            motAAfficher += motCache[i];
        }
        return motAAfficher;
    }
    // fonction pour valider les lettres
    public void ValidationLettre(bool lettrePresente, char lettre, Image image)
    {
        if (lettrePresente)
        {
            AfficherMot(lettre);
            penduStarter.uIManager.ResultatLettre(image, Color.green);
        }
        else
        {
            essais++;
            penduStarter.uIManager.ResultatLettre(image, Color.red, essais);
        }
        TestGameOver();
    }

    //teste si on gagne :
    public void TestGameOver()
    {
        if (essais == 7)
        {
            gameOver = true;
            penduStarter.uIManager.MessageGameOver(Color.red,"Perdu ! le roi est mort, vive le roi!");
        }
        if (motADeviner == CreationMot())
        {
            gameOver = true;
            penduStarter.uIManager.MessageGameOver(Color.green,"Bravo ! tu as sauvé Viserys !");
        }

    }


}
