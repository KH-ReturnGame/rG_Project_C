Shader "Unlit/colorblind"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {} // 텍스처 프로퍼티 정의
        _ColorBlindType ("Color Blind Type", Range(0, 2)) = 0
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

            sampler2D _MainTex; // 텍스처 샘플러 선언
            float _ColorBlindType;

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

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv); // 텍스처 샘플링

                if (_ColorBlindType == 0)
                {
                    // Protanopia: Red-weak
                    col.rgb = fixed3(col.g, col.g, col.b);
                }
                else if (_ColorBlindType == 1)
                {
                    // Deuteranopia: Green-weak
                    col.rgb = fixed3(col.r, col.r, col.b);
                }
                else if (_ColorBlindType == 2)
                {
                    // Tritanopia: Blue-weak
                    col.rgb = fixed3(col.r, col.g, col.r);
                }

                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}