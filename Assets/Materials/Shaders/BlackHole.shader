Shader "Unlit/BlackHole"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        // _MainTex ("Texture2", 2D) = "white" {}
        _BlackHoleScale ("BlackHoleScale", Float) = 1.0
        _RadiusT1 ("RadiusT1", Float) = 0.44
        _RadiusT2 ("RadiusT2", Float) = 0.6

    }
    SubShader
    {
        // Tags { "RenderType"="Opaque" }
        Tags { "Queue" = "Overlay" }

        LOD 100
        GrabPass { }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            // #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                // UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float4 screenPos : TEXCOORD1; // Screen position for sampling the grab texture
                float radius : TEXCOORD2;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _BlackHoleScale;
            float _RadiusT1;
            float _RadiusT2;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                // o.screenPos;
                o.screenPos = ComputeScreenPos(o.vertex);
                // o.screenPos = ComputeGrabScreenPos(o.vertex);
                // float4 screenPos = float4(1, 1, 1, 1);
                // o.screenPos = screenPos;
                // o.radius = distance(v.vertex.xyz, float3(0, 0, 0)) / _BlackHoleScale;
                
                // UNITY_TRANSFER_FOG(o,o.vertex);

                float3 camPosWorld = _WorldSpaceCameraPos;
                float4 modelPosWorld = mul(unity_ObjectToWorld, float4(0,0,0,1));
                float4 vertexPosWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 modelToCamNorm = normalize(camPosWorld - modelPosWorld.xyz);
                float3 modelToVertex = vertexPosWorld - modelPosWorld;
                o.radius = length(cross(modelToCamNorm, modelToVertex));
                mul(cross(modelToVertex, modelToCamNorm)
                
                return o;
            }
            
            sampler2D _GrabTexture;
            
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                // UNITY_APPLY_FOG(i.fogCoord, col);
                
                float dist = distance(i.uv, float2(0.5, 0.5));
                // return float4(dist, dist, dist, 1);
                
                float2 screenUV = i.screenPos.xy / i.screenPos.w;
                float4 grabbedColor = tex2D(_GrabTexture, screenUV);
                float rad = i.radius / _BlackHoleScale;

                float blackHoleColor = float4(0.0, 0.0, 0.0, 1.0);

                float ring_mask = _RadiusT1 < rad && rad < _RadiusT2 ? 1.0 : 0.0;
                float distort_mask = rad >= _RadiusT2 ? 1.0 : 0.0;

                float3 ringColor = float3(1.0, 0.0, 0.0) * ring_mask;
                float3 starColor = grabbedColor * distort_mask;
                float3 a = ringColor + starColor;
                // float3 a = ringColor;
                // float3 a = starColor;
                // a = distort_mask;


                return float4(a.r, a.g, a.b, 1.0);

                // float4 grabbedColor = tex2D(_GrabTexture, i.uv);
                // return float4(i.edge, i.edge, i.edge, 1.0);
                // return grabbedColor * 0.5;

                // return col;
            }
            ENDCG
        }
    }
}
