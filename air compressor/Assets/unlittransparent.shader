Shader "Unlit Transparent Color"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        LOD 100
        Fog {Mode Off}
        Cull Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        Color [_Color]

        Pass {}
    }
}