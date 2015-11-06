Shader "Custom/AlphaBlend" {
    Properties {
        _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
    }
 
    SubShader {
        Tags { "Queue"="Overlay" }
        Blend One OneMinusSrcAlpha
        Lighting Off
        Fog { Mode Off }
        ZWrite Off
        Cull Off
        ColorMaterial AmbientAndDiffuse
 
        Pass {
            SetTexture [_MainTex] {
               combine texture * primary
            }
 
            SetTexture [_MainTex] {
               combine previous * previous alpha
            }
        }
    }
}
