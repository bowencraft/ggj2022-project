using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHolderManager : MonoBehaviour
{
    public GameObject[] PlantSpritesList;

    private int PlantType = 0; // Plant sprites are decided by type, status and stage
    private int PlantStage = 0;
    private int PlantStatus = 0; // 0 - growing, 1 - stop growing (event happens), 2 - mature, 3 - illness, 4 - die
    private int TimeRemainToNextStage = -1;

    PlantObjectProperty plantProperty = null;
    SpriteRenderer p_SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        p_SpriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (PlantStatus == 0)
        {
            if (TimeRemainToNextStage > 0) // time minus
            {
                TimeRemainToNextStage--;
            }
            else if (TimeRemainToNextStage == 0) // grow to next stage
            {
                if (PlantStage < 4)
                {
                    PlantStage++;
                    TimeRemainToNextStage = plantProperty.getStageTime();
                    p_SpriteRenderer.sprite = plantProperty.getSprite(0, PlantStage, 0);
                }
                else
                {
                    TimeRemainToNextStage = -1;
                    PlantStatus = 2;
                }
            }
            else { } // mature or die

        }
        //GetComponent<SpriteRenderer>() = p_SpriteRenderer;
    }

    void addNewPlant(int type) {

        plantProperty = PlantSpritesList[type].GetComponent<PlantObjectProperty>();
        PlantType = type;
    }
}
