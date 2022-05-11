// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Proximity" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {} // Regular object texture 
		//_PlayerPosition("Player Position", vector) = (0,0,0,0) // The location of the player - will be set by script
		//_ShotPosition("Shot Position", vector) = (0,0,0,0) // The location of the shot - will be set by script
		_PVisibleDistance("Player Visibility Distance", float) = 2.0 // How close does the player have to be to make object visible
		_SVisibleDistance("Shot Visibility Distance", float) = 4.0 // How close does the player have to be to make object visible
		//_UseShot("Use Shot", float) = 0
	}

	SubShader{

	Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }
	Pass{
	Blend SrcAlpha OneMinusSrcAlpha
	LOD 200

	CGPROGRAM

#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

	// Access the shaderlab properties
	uniform sampler2D _MainTex; //Main texture
	uniform float4 _MainTex_ST; //Tiling and offset values
	uniform float4 _PlayerPosition;
	uniform float4 _ShotPosition;
	uniform float _PVisibleDistance;
	uniform float _SVisibleDistance;
	uniform float _UseShot;

	// Input to vertex shader
	struct vertexInput {
		float4 vertex : POSITION;
		float2 uvs : TEXCOORD0;
	};

	// Input to fragment shader
	struct vertexOutput {
		float4 pos : SV_POSITION;
		float4 position_in_world_space : TEXCOORD0;
		float2 tex : TEXCOORD1;
	};

	// VERTEX SHADER
	vertexOutput vert(vertexInput input) {
		vertexOutput output;
		output.pos = UnityObjectToClipPos(input.vertex);
		output.position_in_world_space = mul(unity_ObjectToWorld, input.vertex);
		output.tex = TRANSFORM_TEX(input.uvs, _MainTex); //Apply scaling
		return output;
	}

	// FRAGMENT SHADER
	float4 frag(vertexOutput input) : COLOR {

		// Calculate distance to player or bullet
		float distPlayer = _PVisibleDistance - distance(input.position_in_world_space, _PlayerPosition);
		float distShot = _SVisibleDistance - distance(input.position_in_world_space, _ShotPosition) - (1 - _UseShot) * _SVisibleDistance;

		float dist = max(distPlayer, distShot);
		float alpha = step(0, dist);

		// Return appropriate colour alpha
		float4 tex = tex2D(_MainTex, input.tex);
		tex.a *= alpha;
		return tex;
	}

		ENDCG
	}
	}
		//FallBack "Diffuse"
}