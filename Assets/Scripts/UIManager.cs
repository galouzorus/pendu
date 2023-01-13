using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private PenduStarter starter;
    public GameObject PanelFin;
    public TextMeshProUGUI affichageMot;
    public Sprite[] pend;
    public GameObject Pendu;

    //awake
    private void Awake()
    {
        starter = GetComponent<PenduStarter>();
    }
    //Pression sur boutons et test
    public void KeyboardPress()
    {
        if (!starter.penduManager.gameOver)
        {
            GameObject go = EventSystem.current.currentSelectedGameObject;
            Image image = go.GetComponent<Image>();
            Button button = go.GetComponent<Button>();
            Text textMesh = go.GetComponentInChildren<Text>();
            char letter = textMesh.text[0];
            button.interactable = false;

            starter.penduManager.TestLettre(letter, image);
        }
    }
    //changement etat bouton lettre rouge ou vert
    public void ResultatLettre(Image image, Color color)
    {
        image.color = color;
    }
    
    //changement 
    public void ResultatLettre(Image image,Color color,int essais)
    {
        image.color = color;
        Pendu.GetComponent<Image>().sprite = pend[essais];
    }
    public void MessageGameOver(Color color,string message)
    {
        PanelFin.SetActive(true);
        TextMeshProUGUI finalText = PanelFin.GetComponentInChildren<TextMeshProUGUI>();
        finalText.color = color;
        finalText.text = message;
    }
    //restart ou quit
  public void Restart()
  {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
  public void Quit()
  {
#if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
#endif
      Application.Quit();
  }

}
