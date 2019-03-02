Shader "Hidden/linesdistortion"
{
	Properties
	{
		[HideInInspector]
		[NoScaleOffset]
		_MainTex ("Texture", 2D) = "white" {}
		_Noise ("Noise", 2D) = "white"
		_Amount ("Amount", Float) = 0.05
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

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

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _Noise;
			float4 _Noise_ST;
			float _Amount;

			fixed4 frag (v2f i) : SV_Target
			{
				return tex2D(_MainTex, i.uv + float2(0, (tex2D(_Noise, (float2(i.uv.x, 0) + _Noise_ST.zw) * _Noise_ST.xy).r - 0.5) * _Amount));
			}
			ENDCG
		}
	}
}
