Shader "MathGame/CutwayAndTint"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Cutoff ("Alpha Cutoff", Float) = 0.5
		_Color ("Tint", Color) = (1,1,0,1)

	}
	SubShader
	{
		
		Pass
		{
			
         Cull Off 

         CGPROGRAM

         #pragma vertex vert  
         #pragma fragment frag 

		 uniform sampler2D _MainTex;
         uniform float _Cutoff;

		 struct vertexInput  {
            float4 vertex : POSITION;
            float4 texcoord : TEXCOORD0;
			};

		 struct vertexOutput {
			 float4 pos : POSITION;
			 float4 tex : TEXCOORD0;
			 };

		 vertexOutput vert(vertexInput input){
			 vertexOutput output;
			 output.tex = input.texcoord;
			 output.pos = UnityObjectToClipPos(input.vertex);
			 return output;
		 }

		 float4 _Color = (1,1,0,1);

		 float4 frag(vertexOutput input) : COLOR  {

			 float4 textureColor = tex2D(_MainTex, input.tex.xy);  

			 if (textureColor.a < _Cutoff)
			 {
				  discard;
			 }

			 float4 final =	tex2D(_MainTex, input.tex.xy);

            return final * _Color;
         }

         ENDCG
		}
	}
	   Fallback "Unlit/Texture"

}
