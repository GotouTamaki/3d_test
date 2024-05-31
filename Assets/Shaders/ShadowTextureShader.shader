Shader "Custom/ShadowTextureShader"
{
    Properties
    {
           _MainTex ("Texture", 2D) = "white" {}
           _MainColor("Color" ,color) = (1,1,1,1)
           _ShadowTex("ShadowTe",2D) = "white"{}
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include  "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct appdata
            {
                float4 vertex : POSITION;
                half3 normal: NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD;
                float3 normalWS : TEXCOORD1;
            };


            float4 _MainColor;
            sampler2D _ShadowTex;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = TransformObjectToHClip(v.vertex);
                //面の法線を取得、ライトの当たる向きを計算
                VertexNormalInputs normal = GetVertexNormalInputs(v.normal);
                o.uv = v.uv;
                o.normalWS = normal.normalWS;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float4 col = _MainColor;
                //Light.hlslで提供されるUnityのライトを取得する関数
                Light lt = GetMainLight();

                //ライトの向きを計算
                float strength = saturate(dot(lt.direction, i.normalWS));
                float4 lightColor = float4(lt.color, 1);
                float shadow = (1 - smoothstep(0,0.5,strength)) * tex2D(_ShadowTex,i.uv);
                return col * lightColor * strength + shadow;
            }

            ENDHLSL
        }
    }
}