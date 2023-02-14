using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorManager : MonoBehaviour
{
    [SerializeField] private PlayerStatsController playerStatsController;
    [SerializeField] private Outline playerOutline;
    [SerializeField] private MeshRenderer playerMaterial;

    // Start is called before the first frame update
    void Start()
    {
        playerOutline.OutlineColor = ColorBrightness.ChangeColorBrightness(playerStatsController.Color);
        playerMaterial.material.color = playerStatsController.Color;
    }
}
