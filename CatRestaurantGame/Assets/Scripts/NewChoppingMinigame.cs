using UnityEngine;
using UnityEngine.UI;

public class NewChoppingMinigame : MonoBehaviour
{
    
    [SerializeField] private Slider knifeSlice;
    [SerializeField] private Slider progressBar;
     private MiniGameUI miniGameUI;

    private bool isDragging = false;
    private float lastSliderValue;

    private int[] chopAmounts = { 4, 5, 6, 7, 8 };
    private int chopsDone = 0;

    private int requiredChops;

   

    private bool reachedTop = false;


    private void Start()
    {

        miniGameUI = FindAnyObjectByType<MiniGameUI>();
        ResetMiniGame();
    }

    void OnEnable()
    {
        ResetMiniGame();
    }

    private void Update()
    {
        HandleMouseDrag();

       
    }

    void HandleMouseDrag()
    {
        if (Input.GetMouseButton(0))
        {
            isDragging = true;
        } else
        {
            isDragging = false;
        }


        if (isDragging)
        {
            float mouseY = Input.GetAxis("Mouse Y");
            knifeSlice.value += mouseY * .05f;

            if (knifeSlice.value >= 0.9f)
            {
                reachedTop = true;
            }

            if (reachedTop && knifeSlice.value <= .1f)
            {
                chopsDone++;
                progressBar.value = chopsDone;
                reachedTop = false;


                if (chopsDone >= requiredChops)
                {
                    miniGameUI.CloseAllMinigames();
                }
            }
            lastSliderValue = knifeSlice.value;
        }

      
      
        
    }

    void ResetMiniGame()
    {
        chopsDone = 0;
        requiredChops = chopAmounts[Random.Range(0, chopAmounts.Length)];
        lastSliderValue = knifeSlice.value;
        progressBar.maxValue = requiredChops;
        progressBar.value = 0;
    }

}
