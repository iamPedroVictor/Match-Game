Shader "MathGame/TransitionShader" {
	Properties{
		_ColorA("Color A", Color) = (1,1,1,1)
		_ColorB("Color B", Color) = (0,0,0,1)
		_Cutoff("Cutoff" , Range(0,1)) = 0
	}
	SubShader {


		Pass
		{
			CGPROGRAM
			//#pragma vertex vert
			//#pragma fragment frag

			ENDCG
		}
	}

}
