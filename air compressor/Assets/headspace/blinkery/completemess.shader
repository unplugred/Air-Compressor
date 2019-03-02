Shader "Unlit/NewUnlitShader 1"
{
	Properties
	{
		_colour ("colour", Color) = (0,0,0,0)
		_MainTex ("Texture", 2D) = "white" {}
		ddd ("fff", Float) = 1
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
			float4 _MainTex_ST;
			float ddd;
			float4 _colour;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex + float4(
					(tex2Dlod(_MainTex, float4(v.vertex.x + _MainTex_ST.x,v.vertex.y + _MainTex_ST.z,0,0)).r - 0.5)*ddd,
					(tex2Dlod(_MainTex, float4(v.vertex.x + _MainTex_ST.z,v.vertex.y + _MainTex_ST.y,0,0)).r - 0.5)*ddd,
					(tex2Dlod(_MainTex, float4(v.vertex.y + _MainTex_ST.y,v.vertex.x + _MainTex_ST.w,0,0)).r - 0.5)*ddd,1));
				o.uv = v.uv;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				return _colour;
			}
			ENDCG
		}
	}
}
