﻿Shader "Unlit/loadingscreenlogo"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Mult ("Multiply", Float) = 1
		_Add ("Add", Float) = 0
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float _Mult;
			float _Add;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				return (tex2D(_MainTex, i.uv).r + _Add) * _Mult;
			}
			ENDCG
		}
	}
}
