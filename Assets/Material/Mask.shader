Shader "Custom/Mask"
{
    SubShader
    {
       Tags
       {
		   "Queue" = "Geometry-1"
       }
       Zwrite On
       ColorMask 0
       Pass {}
    }
}
