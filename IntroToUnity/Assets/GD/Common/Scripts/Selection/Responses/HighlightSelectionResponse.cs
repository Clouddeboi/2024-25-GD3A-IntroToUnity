using UnityEngine;

namespace GD.Selection
{
    public class HighlightSelectionResponse : MonoBehaviour, ISelectionResponse
    {
        [SerializeField]
        private Material highlightMaterial;

        private Material originalMaterial;

        //Called when we select a NEW thing - transform is the ref to new thing
        public void OnSelect(Transform transform)
        {
            var renderer = transform.GetComponent<Renderer>();

            //remember old material
            originalMaterial = renderer.material;
            //set to new material
            renderer.material = highlightMaterial;
        }

        //Called when we deselect something - transform is the old selected thing
        public void OnDeselect(Transform transform)
        {
            var renderer = transform.GetComponent<Renderer>();

            //am i deselecting a valid renderer? did i record its original material?
            if (originalMaterial != null && renderer != null)
                renderer.material = originalMaterial;
        }
    }
}