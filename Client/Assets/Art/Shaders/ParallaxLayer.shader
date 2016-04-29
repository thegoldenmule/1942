Shader "Space/ParallaxLayer"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_uvScroll ("Float", Float) = 1
	}

	CGINCLUDE 

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

		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform float _uvScroll;
			
		v2f vert (appdata v)
		{
			v2f o;
			o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			o.uv = TRANSFORM_TEX(v.uv, _MainTex);
			return o;
		}
			
		fixed4 frag (v2f i) : SV_Target
		{
			return tex2D(_MainTex, float2(i.uv.x, i.uv.y + _uvScroll));
		}

	ENDCG

	SubShader
	{
		Tags { "RenderType"="Opaque" }
		Blend SrcAlpha OneMinusDstAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			ENDCG
		}
	}
}
