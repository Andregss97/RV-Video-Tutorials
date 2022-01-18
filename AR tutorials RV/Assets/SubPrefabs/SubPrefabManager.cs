using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
            /*GameObject easy = GameObject.FindWithTag("easy");
            GameObject medium = GameObject.FindWithTag("medium");
            GameObject hard = GameObject.FindWithTag("hard");
            
            string name =  EventSystem.current.currentSelectedGameObject.name;

            if(name.CompareTo("easy") == 0){ easy.SetActive(true); }
            if(name.CompareTo("medium") == 0){ medium.SetActive(true); }
            if(name.CompareTo("hard") == 0){ hard.SetActive(true); }*/

            if (trackedImage != null)
            {
                foreach (SubPrefabTargetImagePicker picker in SubPrefabs)
                {
                    Debug.Log(picker.image.name);
                    if (picker.image == trackedImage?.referenceImage && (universalPlayer.staticPlayer.clip == picker.clip || picker.clip == null))
                        picker.TurnOn();
                    else
                        picker.TurnOff();
                }
            }
        }
    }
}