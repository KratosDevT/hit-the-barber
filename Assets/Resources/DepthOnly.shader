Shader "Custom/DepthOnly"
{
    SubShader
    {
        Tags { "Queue"="Geometry-1" "RenderType"="Opaque" }
        ColorMask 0  // Non scrive nel buffer dei colori
        ZWrite On    // Scrive nel depth buffer
        Pass { }
    }
}