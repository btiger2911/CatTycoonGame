using UnityEngine;

public class MiniGameUI : MonoBehaviour
{

    [SerializeField] GameObject choppingGamePanel;
    [SerializeField] GameObject fryingGamePanel;
    [SerializeField] GameObject mixingGamePanel;

    private bool isMiniGameActive = false;
  
    void Start()
    {
           CloseAllMinigames();
            
    }


    private void Update()
    {
        
    }


    public void MiniGameOpen(string cookingStation)
    {

       if (!isMiniGameActive)
        {
            CloseAllMinigames();

            switch (cookingStation)
            {
                case "Chopping":
                    choppingGamePanel.SetActive(true);
                    break;
                case "Frying":
                    fryingGamePanel.SetActive(true);
                    break;

                case "Mixing":
                    mixingGamePanel.SetActive(true);
                    break;
            }

            isMiniGameActive = true;
            Time.timeScale = 0f;
        }

           
        
       
    }

   


    public void CloseAllMinigames()
    {
        choppingGamePanel.SetActive(false);
        fryingGamePanel.SetActive(false);
        mixingGamePanel.SetActive(false);

        isMiniGameActive = false;
        Time.timeScale = 1f;
    }

    public bool IsMiniGameActive()
    {
        return isMiniGameActive;
    }
}
