//    Copyright (C) 2020 Ned Makes Games

//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.

//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License for more details.

//    You should have received a copy of the GNU General Public License
//    along with this program. If not, see <https://www.gnu.org/licenses/>.

using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Glitch : MonoBehaviour
{

    [SerializeField] private Renderer2DData rendererData = null;
    [SerializeField] private string featureName = null;

   /* private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGlitch();
        }
    }*/


    private bool TryGetFeature(out ScriptableRendererFeature feature)
    {
        feature = rendererData.rendererFeatures.Where((f) => f.name == featureName).FirstOrDefault();
        return feature != null;
    }

    public void StartGlitch()
    {
        if(TryGetFeature(out var feature))
        {
            feature.SetActive(true);
            Invoke("EndGlitch", 0.1f);
        }

    }

    public void EndGlitch()
    {
        if (TryGetFeature(out var feature))
        {
            feature.SetActive(false);
        }
    }
}