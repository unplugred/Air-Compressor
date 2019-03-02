Shader "Unlit/NewUnlitShader"
{
	Properties
	{
		_colour ("colour", Color) = (0,0,0,0)
		_waves ("waves", 2D) = "gray"
		_amount ("amonut", float) = 1
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }

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

			float4 _colour;
			sampler2D _waves;
			float _amount;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.vertex = o.vertex + float4((tex2Dlod(_waves, float4(o.vertex.xy * 0.5 + 0.5,0,0)).r - 0.5)*_amount,0,0,0);
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
