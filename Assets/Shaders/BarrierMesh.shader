// Based on example found on Unity Wiki

Shader "Quill18/Alpha Blended Falloff" {
	Properties {
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Texture", 2D) = "white" {}
		_FadeDistance ("Fade Start Distance", float) = 10
	}

	SubShader {
		Tags { "Queue" = "Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		AlphaTest Greater .01
		ColorMask RGB
		Lighting Off
		ZWrite Off
		Fog { Color (0,0,0,0) }
		Pass {
			CGPROGRAM
				#pragma exclude_renderers d3d11 xbox360
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile_builtin
				#pragma fragmentoption ARB_fog_exp2
				#pragma fragmentoption ARB_precision_hint_fastest
				#include "UnityCG.cginc"
				
				uniform float4	_MainTex_ST,
								_TintColor;
				uniform float _FadeDistance;
				
				struct appdata_vert {
					float4 vertex : POSITION;
					float4 texcoord : TEXCOORD0;
					float4 color : COLOR;
				};
				
				uniform sampler2D _MainTex;
				
				struct v2f {
					float4 pos : SV_POSITION;
					float2	uv;
					float4 color;
				};
				
				v2f vert (appdata_vert v) {
					v2f o;
					o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
					o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
					float4 viewPos = mul(UNITY_MATRIX_MV, v.vertex);
					float alpha = (-viewPos.z - _ProjectionParams.y)/_FadeDistance;
					alpha = min(alpha, 1);
					alpha = 1 - alpha;	// Inverse falloff
					o.color = float4(v.color.rgb, v.color.a*alpha);
					o.color *= _TintColor*2;
					return o;
				}
				
				float4 frag (v2f i) : COLOR {
					half4 texcol = tex2D( _MainTex, i.uv );
					
					return texcol*i.color;
				}
			ENDCG
		}
	}
	
	Fallback "Particles/Alpha Blended"
}
