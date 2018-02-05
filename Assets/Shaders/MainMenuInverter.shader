// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/NewSurfaceShader55" {

	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}

	SubShader
	{
		Tags{ "RenderType" = "ASDF" "Queue" = "Overlay+100" "IgnoreProjector" = "True" }

		Blend OneMinusDstColor Zero
		ColorMask RGB

		ZWrite Off
		ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			float4 vert(float4 vertex : POSITION) : SV_Position{
				return UnityObjectToClipPos(vertex);
			}

			sampler2D _MainTex;

			fixed4 frag(v2f i) : SV_Target {
				return fixed4(1,1,1,1);
			}
			ENDCG
		}
	}
}