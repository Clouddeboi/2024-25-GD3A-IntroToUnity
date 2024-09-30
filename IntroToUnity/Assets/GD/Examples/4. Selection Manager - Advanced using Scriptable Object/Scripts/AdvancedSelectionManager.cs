using GD.Selection;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Allows us to attach multiple responses to a selected object
/// </summary>
public class AdvancedSelectionManager : MonoBehaviour
{
    [SerializeField]
    private IRayProvider rayProvider;

    [SerializeField]
    private ISelector selector;

    [SerializeField]
    private ISelectionResponse reponse;

    private Transform currentSelection;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        //get a ray provider
        rayProvider = GetComponent<IRayProvider>();

        //get a selector
        selector = GetComponent<ISelector>();

        //get a reponse
        reponse = GetComponent<ISelectionResponse>();
    }

    private void Update()
    {
    }
}