Shader "Unlit/Fur"
{

Properties
{
    _BaseMap("Base Map", 2D) = "white" {}
    _FurMap("Fur Map", 2D) = "white" {}
    [IntRange] _ShellAmount("Shell Amount", Range(1, 100)) = 16
    _ShellStep("Shell Step", Range(0.0, 0.01)) = 0.001
    _AlphaCutout("Alpha Cutout", Range(0.0, 1.0)) = 0.1
}

SubShader
{
    Tags 
    { 
        "RenderType" = "Opaque" 
        "RenderPipeline" = "UniversalPipeline" 
        "IgnoreProjector" = "True"
    }

    LOD 100

    ZWrite On
    Cull Back

    Pass
    {
        Name "Unlit"
        HLSLPROGRAM
        #pragma exclude_renderers gles gles3 glcore
        #pragma multi_compile_fog
        #include "./Fur.hlsl"
        #pragma vertex vert
        #pragma require geometry
        #pragma geometry geom 
        #pragma fragment frag
        ENDHLSL
    }

    Pass
    {
        Name "DepthOnly"
        Tags { "LightMode" = "DepthOnly" }

        ZWrite On
        ColorMask 0

        HLSLPROGRAM
        #pragma exclude_renderers gles gles3 glcore
        #pragma vertex DepthOnlyVertex
        #pragma fragment DepthOnlyFragment
        #include "Packages/com.unity.render-pipelines.universal/Shaders/UnlitInput.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/Shaders/DepthOnlyPass.hlsl"
        ENDHLSL
    }

    Pass
    {
        Name "ShadowCaster"
        Tags {"LightMode" = "ShadowCaster" }

        ZWrite On
        ZTest LEqual
        ColorMask 0

        HLSLPROGRAM
        #pragma exclude_renderers gles gles3 glcore
        #pragma target 4.5
        #pragma vertex ShadowPassVertex
        #pragma fragment ShadowPassFragment
        #include "Packages/com.unity.render-pipelines.universal/Shaders/LitInput.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/Shaders/ShadowCasterPass.hlsl"
        ENDHLSL
    }
}
