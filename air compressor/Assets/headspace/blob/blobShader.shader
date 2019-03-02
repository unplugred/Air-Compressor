Shader "Unlit/blobShader"
{
	Properties
	{
		_Displace ("Displace", 2D) = "white" {}
		_Color ("Color", Color) = (0,0,0,0)
		_Amount ("Amount", Float) = 0
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

			sampler2D _Displace;
			float4 _Displace_ST;
			fixed4 _Color;
			float _Amount;
			
			v2f vert (appdata v)
			{
				v2f o;
				float2 texcords = TRANSFORM_TEX(float2(v.vertex.x + v.vertex.z * 0.5, v.vertex.y + v.vertex.z * 0.5), _Displace);
				o.uv = v.uv;
				o.vertex = v.vertex * (_Amount * (tex2Dlod(_Displace, float4(texcords, 0, 1)).r + 0.5) + 1 * (1 - _Amount));
				o.vertex = UnityObjectToClipPos(o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				return _Color;
			}
			ENDCG
		}
	}
}
