using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace RVir.GrupoTres
{
    /// <summary>
    /// Manages SubPrefabTargetImagePicker components. Add to the root object of your prefab.
    /// </summary>
    public class SubPrefabManager : MonoBehaviour
    {
        public List<SubPrefabTargetImagePicker> SubPrefabs = new List<SubPrefabTargetImagePicker>();

        private ARTrackedImage _trackedImage = null;
        public ARTrackedImage trackedImage
        {
            get => _trackedImage ??= GetComponent<ARTrackedImage>();
        }

        void Start()
        {
            if (trackedImage != null)
            {
                foreach (SubPrefabTargetImagePicker picker in SubPrefabs)
                {
                    Debug.Log(picker.image.name);
                    if (picker.image == trackedImage?.referenceImage)
                        picker.TurnOn();
                    else
                        picker.TurnOff();
                }
            }
        }
    }
}


